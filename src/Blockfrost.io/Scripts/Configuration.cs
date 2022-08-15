using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Blockfrost {

    [Serializable]
    public class Server {
        public string Network;
        public string Url;
        public string User;

        public string FullUrl() {
            return $"https://{Url}";
        }

        public string FullUrl(string projectId) {
            return $"https://{User}:{projectId}@{Url}";
        }
    }

    [CreateAssetMenu(menuName = "Blockfrost.io API/Configuration", fileName = "BlockfrostAPIConfiguration")]
    public class Configuration : ScriptableObject {
        [Tooltip("Authentication token (project_id)")]
        [SerializeField]
        public string ProjectId;

        public const string CardanoApi = "Cardano";
        public const string MilkomedaApi = "Milkomeda";

        [Tooltip("Client request timeout (0 = no timeout)")]
        [SerializeField]
        public int RequestTimeout;
        [Tooltip("Enable detailed debug logging")]
        [SerializeField]
        public bool DebugLogging;

        [SerializeField]
        [HideInInspector]
        private string _currentApi = CardanoApi;

        public string CurrentApi { get => _currentApi; protected set => _currentApi = value; }

        private int _currentNetworkIndex;
        public int CurrentNetworkIndex { get => _currentNetworkIndex; protected set => _currentNetworkIndex = value; }

        public Server CurrentServer { get => servers[CurrentApi][CurrentNetworkIndex]; }

        [SerializeField]
        [HideInInspector]
        public Dictionary<string, List<Server>> servers = new Dictionary<string, List<Server>> {{
            CardanoApi, new List<Server>{
                new Server{
                    Network = "Mainnet",
                    Url = "cardano-mainnet.blockfrost.io/api/v0",
                },
                new Server{
                    Network = "Testnet",
                    Url = "cardano-testnet.blockfrost.io/api/v0",
                },
            }}, {
            MilkomedaApi, new List<Server>{
                new Server{
                    Network = "Mainnet",
                    Url = "milkomeda-mainnet.blockfrost.io/api/v0/",
                    User = "milkmainnet",
                },
                new Server{
                    Network = "Testnet",
                    Url = "milkomeda-testnet.blockfrost.io/api/v0/",
                    User = "milktestnet",
                },
            }},
        };

        public void ChangeApi(string api) {
            if (!servers.ContainsKey(api)) throw new KeyNotFoundException($"invalid API {api}");
            CurrentApi = api;
        }

        public void ChangeNetwork(int index) {
            if (index >= servers.Count) {
                Debug.LogError($"Invalid network index {index}");
                return;
            }
            CurrentNetworkIndex = index;
        }

    }
}
