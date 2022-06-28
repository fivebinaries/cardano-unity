using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif

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

        public int CurrentServerIndex { get => _currentServerIndex; set => _currentServerIndex = value; }
        public Server CurrentServer { get => servers[CurrentServerIndex]; }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(Configuration))]
    public class ConfigurationEditor : Editor {
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            var conf = target as Configuration;
            var _servers = conf.servers.Select(s => s.Name).ToArray();

            GUILayout.Label("Current server:");
            int _currentServerIndex = conf.CurrentServerIndex;
            conf.CurrentServerIndex = EditorGUILayout.Popup(conf.CurrentServerIndex, _servers);

            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.TextField("Url", conf.CurrentServer.Url);
            EditorGUILayout.Separator();
            // TODO OAInfo
            EditorGUI.EndDisabledGroup();

            EditorUtility.SetDirty(target);
        }
    }
#endif
}