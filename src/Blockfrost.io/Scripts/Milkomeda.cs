using System;

using Cysharp.Threading.Tasks;

using UnityEngine.Networking;

namespace Blockfrost {
    public class Milkomeda : Client {

        public Milkomeda() : base() { }
        public Milkomeda(Configuration config) : base(config) { }

        private string Url { get => configuration.CurrentServer.FullUrl(configuration.ProjectId); }

        public async UniTask<string> RPC(string json) {
            if (json == null || json.Length == 0) {
                throw new ArgumentNullException("json");
            }

            byte[] payload = new System.Text.UTF8Encoding().GetBytes(json);
            return await Post(Url, payload);
        }
    }

}