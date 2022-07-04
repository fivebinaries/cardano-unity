using System.Collections.Generic;
using System;
using UnityEngine;

namespace Blockfrost {

    [Serializable]
    public class Server {
        public string Name;
        public string Url;
    }

    [Serializable]
    public class OAInfo {
        public string Title;
        public string Description;
        public string Version;
        public string TermsOfService;
        public OAContact Contact;
        public OALicense License;
    }

    [Serializable]
    public class OAContact {
        public string Name;
        public string Url;
        public string Email;
    }

    [Serializable]
    public class OALicense {
        public string Name;
        public string Url;
    }

    [CreateAssetMenu(menuName = "Blockfrost.io API/Configuration", fileName = "BlockfrostAPIConfiguration")]
    public class Configuration : ScriptableObject {
        [Tooltip("Authentication token (project_id)")]
        [SerializeField]
        public string ProjectID;

        [Tooltip("Client request timeout (0 = no timeout)")]
        [SerializeField]
        public int RequestTimeout;

        public bool DebugLogging;

        [SerializeField]
        [HideInInspector]
        private int _currentServerIndex;

        [SerializeField]
        [HideInInspector]
        public List<Server> servers = new List<Server> {
          new Server{
                 Name = "Cardano Mainnet network",
                 Url = "https://cardano-mainnet.blockfrost.io/api/v0",
              },
          new Server{
                 Name = "Cardano Testnet network",
                 Url = "https://cardano-testnet.blockfrost.io/api/v0",
              },
        };

        public OAInfo info;

        public int CurrentServerIndex { get => _currentServerIndex; protected set => _currentServerIndex = value; }
        public Server CurrentServer { get => servers[CurrentServerIndex]; }

        public void ChangeServer(int index) {
            if (index >= servers.Count) {
                Debug.LogError($"Invalid server index {index}");
                return;
            }
            CurrentServerIndex = index;
        }

    }
}
