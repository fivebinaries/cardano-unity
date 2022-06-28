using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

using UnityEngine;


namespace BlockfrostGen {

    class Endpoint {
        public static readonly Dictionary<string, bool> SupportedTypes = new Dictionary<string, bool> {
            { "array", true },
            { "object", true },
            { "string", true },
        };

        private const string pathParamsDict = "pathParams";

        public string Method; // TODO enum
        public string Path;
        public string Description;
        public string Summary;
        public List<Param> Params;
        private List<Param> PathParams { get => Params.Where(p => p.In == "Path").ToList<Param>(); }
        private List<Param> QueryParams { get => Params.Where(p => p.In == "Query").ToList<Param>(); }

        public string ResponseType;
        public bool ReturnsArray;

        private bool IsSupported() {
            return Method == "Get" && Summary != null && ResponseType != null;
        }

        public string Serialize() {
            if (!IsSupported()) {
                Debug.Log($"Skipping endpoint {Method} {Path}");
                return null;
            }
            var sb = new StringBuilder();
            AddDocumentation(sb);
            sb.AppendLine($"public async UniTask<{ReturnType}> {Name}({Arguments()}) {{");
            sb.AppendLine($"const string path = \"{Path}\";");
            AddParamsDict(sb, PathParams, pathParamsDict);
            sb.AppendLine($"return await {ClientCall()}(path, {pathParamsDict}{queryParam});");
            sb.AppendLine("}");
            return sb.ToString();
        }

        private void AddParamsDict(StringBuilder sb, List<Param> parameters, string target) {
            sb.Append($"var {target} = new Dictionary<string, object>()");
            if (parameters.Count == 0) {
                sb.AppendLine(";");
                return;
            }
            sb.AppendLine("{");
            foreach (Param p in parameters) {
                sb.AppendLine($"\t\t\t\t{{\"{p.Key}\", {p.Var}}},");
            }
            sb.AppendLine("\t\t\t};");
        }

        private string Name { get => $"{Method}{BlockfrostGenerator.Camelize(Summary)}"; }

        private string Arguments() {
            var pathParams = PathParams.Select(p => $"{BlockfrostGenerator.BasicTypes[p.Type]} {p.Var}");
            pathParams = pathParams.Append(QueryParam());
            return string.Join(", ", pathParams.Where(s => !string.IsNullOrEmpty(s)));
        }

        private static readonly Dictionary<string, HashSet<string>> querySets = new Dictionary<string, HashSet<string>>() {
            {"Listing",new HashSet<string>() { "count", "page" }},
            {"OrderedListing", new HashSet<string>(){ "count", "page", "order" }},
            {"TargetableOrderedListing", new HashSet<string>(){ "count", "page", "order", "from", "to" }},
        };

        // TODO rewrite this to something sane
        private string QueryParam() {
            var qp = QueryParams.Select(qp => qp.Key).ToHashSet();
            foreach (var set in querySets) {
                if (qp.SetEquals(set.Value)) {
                    return $"{set.Key} query = null";
                }
            }
            return null;
        }
        private string queryParam { get => QueryParam() != null ? ", query": ""; }

        private string ClientCall() {
            var method = ReturnsArray ? $"{Method}Array" : Method;
            return $"{method}<{ResponseType}>";
        }

        private string ReturnType { get => ReturnsArray ? $"{ResponseType}[]" : ResponseType; }

        private void AddDocumentation(StringBuilder sb) {
            if (Description == null) {
                return;
            }
            sb.AppendLine("/// <summary>");
            var reader = new StringReader(Description);
            for (string line = reader.ReadLine(); line != null; line = reader.ReadLine()) {
                sb.AppendLine($"/// {line}");
            }
            sb.AppendLine("/// </summary>");
            sb.AppendLine($"/// <remarks>{Method.ToUpper()} {Path}</remarks>");
            foreach (Param pp in PathParams) {
                sb.AppendLine($"/// <param name=\"{pp.Var}\">{pp.Description}</param>");
            }
        }
    }

    class Param {
        public string In;
        public string Type;
        public string Key;
        public string Description;
        public bool Required;
        public string Optional { get => Required ? "" : " (optional)"; }
        public string Var { get => BlockfrostGenerator.Camelize(Key, lowerCase: true); }
    }

}