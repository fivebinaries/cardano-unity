using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Microsoft.OpenApi.Validations;
using Microsoft.OpenApi.Readers;
using Microsoft.OpenApi.Models;

using UnityEngine;
using UnityEditor;

using Newtonsoft.Json;

namespace BlockfrostGen {
    [CreateAssetMenu(menuName = "Blockfrost.io API/Generator", fileName = "BlockfrostGenerator")]
    public class BlockfrostGenerator : ScriptableObject {
        [SerializeField]
        [HideInInspector]
        private TextAsset OpenAPISpecification = null;

        [SerializeField]
        public string Path = "Assets";

        // TODO output folder for generating with a default
        // + gitignore
        // + copy script

        private static string bfNamespace = "Blockfrost";

        public void ParseFromAsset() {
            var doc = Parse(OpenAPISpecification.text);
            GenerateAssets(doc);
        }

        public OpenApiDocument Parse(string json) {
            var stream = CreateStream(json);
            var parsed = new OpenApiStreamReader(new OpenApiReaderSettings {
                ReferenceResolution = ReferenceResolutionSetting.ResolveLocalReferences,
                RuleSet = ValidationRuleSet.GetDefaultRuleSet()
            }).Read(stream, out var openApiDiagnostic);
            Debug.Log("Successfully parsed API Description: " + parsed.Info.Title);
            return parsed;
        }

        List<Endpoint> Endpoints;
        Dictionary<string, ResponseModel> Models;

        public void GenerateAssets(OpenApiDocument doc) {
            Endpoints = new List<Endpoint>();
            Models = new Dictionary<string, ResponseModel>();

            ParseDocument(doc);
            GenerateModels();
            GenerateAPI();
            CreateConfiguration(doc);
        }

        void GenerateModels() {
            var sb = new StringBuilder();
            Imports(sb, new[] { "System" });
            sb.AppendLine($"namespace {bfNamespace} {{");
            foreach (var model in Models) {
                var m = model.Value.Serialize();
                sb.AppendLine(m);
            }
            sb.AppendLine("}");

            File.WriteAllText($"./BFModels.cs", sb.ToString());
        }

        void CreateConfiguration(OpenApiDocument doc) {
            var config = ScriptableObject.CreateInstance<Blockfrost.Configuration>();
            config.servers = doc.Servers.Select(s => new Blockfrost.Server{
                Name = s.Description,
                Url = s.Url,
            }).ToList();
            
            config.info = new Blockfrost.OAInfo{
                Title = doc.Info.Title,
                Description = doc.Info.Description,
                Version = doc.Info.Version,
                TermsOfService = doc.Info.TermsOfService.ToString(),
                Contact = new Blockfrost.OAContact{
                    Name =doc.Info.Contact.Name, 
                    Url = doc.Info.Contact.Url.ToString(),
                    Email = doc.Info.Contact.Email,
                },
                License = new Blockfrost.OALicense{
                    Name = doc.Info.License.Name,
                    Url = doc.Info.License.Url.ToString(),
                }
            };

            AssetDatabase.CreateAsset(config, "Assets/Scripts/Blockfrost/BlockfrostConfiguration.asset");
        }

        void GenerateAPI() {
            var sb = new StringBuilder();
            Imports(sb, new[] { "System.Collections.Generic", "Cysharp.Threading.Tasks" });
            sb.AppendLine($"namespace {bfNamespace} {{");
            sb.AppendLine("public class API : Client {");
            sb.AppendLine("public API() : base() { }");
            sb.AppendLine("public API(Configuration config) : base(config) { }");

            foreach (var endpoint in Endpoints) {
                var e = endpoint.Serialize();
                if (e != null) {
                    sb.AppendLine(e);
                }
            }
            sb.AppendLine("}");
            sb.AppendLine("}");

            File.WriteAllText("./BFAPI.cs", sb.ToString());
        }

        void Imports(StringBuilder sb, string[] imports) {
            foreach (var import in imports) {
                sb.AppendLine($"using {import};");
            }
            sb.AppendLine();
        }

        private void ParseDocument(OpenApiDocument doc) {
            // Endpoints
            foreach (var path in doc.Paths) {
                // Methods
                foreach (var op in path.Value.Operations) {
                    // Debug.Log($"Processing {op.Key} {path.Key}");
                    if (op.Key != OperationType.Get) {
                        Debug.Log($"Skipping unsupported method {op.Key} {path.Key}");
                    }

                    var endpoint = new Endpoint {
                        Path = path.Key,
                        Method = op.Key.ToString(),
                        Description = op.Value.Description,
                        Summary = op.Value.Summary,
                        ReturnsArray = false,
                    };

                    // Parameters
                    endpoint.Params = new List<Param>();
                    foreach (var param in op.Value.Parameters) {
                        endpoint.Params.Add(new Param {
                            In = param.In.ToString(),
                            Type = param.Schema.Type,
                            Key = param.Name,
                            Description = param.Description,
                            Required = param.Required,
                        });
                    }

                    // See if there's a valid response
                    if (!op.Value.Responses.ContainsKey("200")) {
                        Debug.LogError($"Missing 200 response for {endpoint.Method} {endpoint.Path}");
                        continue;
                    }
                    var content = op.Value.Responses["200"].Content;
                    if (!content.ContainsKey("application/json")) {
                        Debug.LogError($"Missing application/json content for {endpoint.Method} {endpoint.Path}");
                        continue;
                    }
                    var schema = content["application/json"].Schema;
                    if (schema == null) {
                        // TODO IPFS special case
                        Debug.LogError($"Missing schema for {endpoint.Method} {endpoint.Path}");
                        continue;
                    }

                    var rt = PrepareModels(schema, Camelize(schema.Reference?.Id ?? endpoint.Summary));

                    if (rt.modelId == null) {
                        Debug.LogError($"Invalid model id for {endpoint.Method} {endpoint.Path} ({Camelize(schema.Reference?.Id ?? endpoint.Summary)})");
                        continue;
                    }

                    endpoint.ReturnsArray = rt.isArray;
                    endpoint.ResponseType = rt.modelId;

                    Endpoints.Add(endpoint);
                }
            }
        }

        private (bool isArray, string modelId) PrepareModels(OpenApiSchema schema, string key) {
            switch (schema.Type) {
                case "string":
                case "integer":
                case "boolean":
                case "number":
                    return (false, BasicTypes[schema.Type]);
                case "array":
                    var rt = PrepareModels(schema.Items, GetModelId(schema, key));
                    return (true, rt.modelId);
                case "object":
                    var modelId = GetModelId(schema, key);
                    if (modelId == null) {
                        Debug.Log($"Skipping model {modelId}|{key}");
                        return (false, null);
                    }
                    if (Models.ContainsKey(modelId)) {
                        return (false, modelId);
                    }
                    // Debug.Log($"Preparing model for {modelId}|{key} of type {schema.Type}");
                    var model = new ResponseModel {
                        ID = modelId,
                        Properties = ParseObjectProperties(schema),
                    };
                    Models[modelId] = model;
                    return (false, modelId);
                default:
                    // TODO support of oneof, etc...
                    Debug.LogError($"Unknown or unsupported type {schema.Type}");
                    return (false, null);
            }
        }

        private List<ResponseProperty> ParseObjectProperties(OpenApiSchema schema) {
            var properties = new List<ResponseProperty>();
            foreach ((var key, var prop) in schema.Properties) {
                var rt = PrepareModels(prop, key);
                properties.Add(new ResponseProperty {
                    Key = key,
                    Type = rt.modelId,
                    IsArray = rt.isArray,
                    Description = prop.Description,
                });
            }

            return properties;
        }

        private string GetModelId(OpenApiSchema schema, string key) {
            return Camelize(schema.Reference?.Id ?? key);
        }

        private MemoryStream CreateStream(string text) {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);

            writer.Write(text);
            writer.Flush();
            stream.Position = 0;

            return stream;
        }

        public static string Camelize(string name, bool lowerCase = false) {
            if (name == null) return null;
            var words = name.Split(new[] { '_', ' ' });
            words = words
                  .Select(word => char.ToUpper(word[0]) + word.Substring(1))
                  .ToArray();

            if (lowerCase) {
                words[0] = words[0].ToLower();
            }

            return string.Join(string.Empty, words);
        }

        public static readonly Dictionary<string, string> BasicTypes = new Dictionary<string, string> {
            { "integer", "int" },
            { "string", "string" },
            { "boolean", "bool" },
            { "number", "float" },
        };
    }

    [CustomEditor(typeof(BlockfrostGenerator))]
    public class BlockfrostGeneratorEditor : Editor {
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            GUILayout.Space(10);

            var t = (BlockfrostGenerator)target;

            GUILayout.BeginVertical();
            var a = serializedObject.FindProperty("OpenAPISpecification");
            EditorGUILayout.ObjectField(a);
            serializedObject.ApplyModifiedProperties();
            if (GUILayout.Button("Parse From Asset")) {
                t.ParseFromAsset();
            }
            GUILayout.EndVertical();

            EditorUtility.SetDirty(target);
        }
    }

}