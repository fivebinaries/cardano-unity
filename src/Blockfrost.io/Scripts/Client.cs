using System.Collections.Generic;
using System.Text;

using UnityEngine.Networking;
using UnityEngine;

using Cysharp.Threading.Tasks;

namespace Blockfrost {

    [System.Serializable]
    public class ArrayWrapper<T> {
        public T[] Items;
    }

    public enum Method {
        get
    }

    public class Client {

        private const string authHeaderKey = "project_id";

        [SerializeField]
        public Configuration configuration;

        public Client() {
            if (configuration == null) {
                // TODO load
                Debug.LogError("Blockfrost API: Missing configuration");
            } else {
                Debug.Log("Blockfrost API (" + configuration.CurrentServer + ")");
            }
        }

        public Client(Configuration config) {
            configuration = config;
        }

        private void LogDebug(object message) {
            if (!configuration.DebugLogging) return;
            Debug.Log(message);
        }

        public async UniTask<string> Call(Method method, string path, Dictionary<string, object> pathParams, Listing query = null) {
            var url = BuildPath(path, pathParams, query);
            LogDebug($"Requesting ({method}) {url}");
            var req = UnityWebRequest.Get(url);
            req.SetRequestHeader(authHeaderKey, configuration.ProjectID);

            // TODO cancellation/abort
            req.timeout = configuration.RequestTimeout;
            var op = await req.SendWebRequest();
            var response = op.downloadHandler.text;

            LogDebug($"Received response:\n{response}");

            return response;
        }

        public async UniTask<T> Get<T>(string path, Dictionary<string, object> pathParams, Listing query = null) {
            var response = await Call(Method.get, path, pathParams, query);
            return JsonUtility.FromJson<T>(response);
        }

        public async UniTask<T[]> GetArray<T>(string path, Dictionary<string, object> pathParams, Listing query = null) {
            var response = await Call(Method.get, path, pathParams, query);
            // wrap array response into object for the unity parser
            response = $"{{\"Items\": {response}}}";
            return JsonUtility.FromJson<ArrayWrapper<T>>(response).Items;
        }

        private string BuildPath(string path, Dictionary<string, object> paramteres, Listing query = null) {
            StringBuilder url = new StringBuilder(configuration.CurrentServer.Url);
            url.Append(path);
            if (paramteres != null) {
                foreach (var p in paramteres) {
                    url.Replace("{" + p.Key + "}", p.Value as string);
                }
            }
            if (query != null) {
                var d = query.AsDict();
                var parsedQuery = UnityWebRequest.SerializeSimpleForm(query.AsDict());
                url.Append($"?{Encoding.UTF8.GetString(parsedQuery)}");
            }
            return url.ToString();
        }

    }

}