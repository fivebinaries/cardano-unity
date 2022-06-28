using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

using UnityEngine;

namespace BlockfrostGen {

    class ResponseModel {
        public string ID;
        public List<ResponseProperty> Properties;

        public string Serialize() {
            var sb = new StringBuilder();
            sb.AppendLine(Header());
            foreach (var property in Properties.Where(prop => prop.IsValid()).ToArray()) {
                sb.AppendLine(property.Serialize());
            }
            sb.AppendLine("}");

            return sb.ToString();
        }

        public string Header() {
            return $"[Serializable]\npublic class {ID} {{";
        }


    }

    class ResponseProperty {
        public string Type;
        public bool IsArray;
        public string Key;

        public string Description;

        public bool IsValid() {
            return Type != null && Key != null;
        }

        public string Serialize() {
            var sb = new StringBuilder();
            Comment(sb);
            Definition(sb);

            return sb.ToString();
        }

        private void Comment(StringBuilder sb) {
            if (Description == null) {
                return;
            }
            sb.AppendLine("/// <summary>");
            var reader = new StringReader(Description);
            for (string line = reader.ReadLine(); line != null; line = reader.ReadLine()) {
                sb.AppendLine($"/// {line}");
            }
            sb.AppendLine("/// </summary>");
        }

        private void Definition(StringBuilder sb) {
            if (Key.Contains('_')) {
                sb.AppendLine($"public {TypeDefinition} {Name()} {{ get => {Key}; }}");
            }
            sb.AppendLine($"public {TypeDefinition} {Key};");
        }

        private string TypeDefinition { get => IsArray ? $"{Type}[]" : Type; }

        private string Name() {
            return BlockfrostGenerator.Camelize(Key, lowerCase: true);
        }
    }
}