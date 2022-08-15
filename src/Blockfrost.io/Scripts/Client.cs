using System.Collections.Generic;
using System.Text;
using System;

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

        protected const string authHeaderKey = "project_id";

        [SerializeField]
        public Configuration configuration;

        public Client() : this(new Configuration()) { }

        public Client(Configuration config) {
            if (config == null) {
                throw new ArgumentNullException("config");
            }
            configuration = config;
            LogDebug($"Initialized Blockfrost API client ({config.CurrentServer.Network})");
        }

        public async UniTask<string> Call(Method method, string path, Dictionary<string, object> pathParams, Listing query = null) {
            var url = BuildPath(path, pathParams, query);
            LogDebug($"Requesting ({method}) {url}");
            var req = UnityWebRequest.Get(url);
            req.SetRequestHeader(authHeaderKey, configuration.ProjectId);

            req.timeout = configuration.RequestTimeout;
            var op = await req.SendWebRequest();
            var response = op.downloadHandler.text;

            LogDebug($"Received response:\n{response}");

            return response;
        }

        public async UniTask<string> Post(string url, byte[] data) {
            var request = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPOST);
            request.timeout = configuration.RequestTimeout;
            request.uploadHandler = new UploadHandlerRaw(data);
            request.uploadHandler.contentType = "application/json";
            request.downloadHandler = new DownloadHandlerBuffer();

            LogDebug($"Sending {request.uploadHandler.data.Length} bytes");
            await request.SendWebRequest();

            var response = request.downloadHandler.text;
            LogDebug($"Received response:\n{response}");

            request.uploadHandler.Dispose();
            request.downloadHandler.Dispose();

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

        protected string BuildPath(string path, Dictionary<string, object> paramteres = null, Listing query = null) {
            StringBuilder url = new StringBuilder(configuration.CurrentServer.FullUrl());
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

        protected void LogDebug(object message) {
            if (!configuration.DebugLogging) return;
            Debug.Log(message);
        }

    }
}