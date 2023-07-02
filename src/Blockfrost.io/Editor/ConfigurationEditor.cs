using System;
using System.Linq;

using UnityEditor;
#if UNITY_EDITOR
using UnityEngine;

[CustomEditor(typeof(Blockfrost.Configuration))]
public class ConfigurationEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        var conf = target as Blockfrost.Configuration;
        var _apis = conf.servers.Select(s => s.Key).ToArray().ToArray();
        GUILayout.Label("Current API");
        int selectedApi = EditorGUILayout.Popup(Array.IndexOf(_apis, conf.CurrentApi), _apis);
        conf.ChangeApi(_apis[selectedApi]);

        var _servers = conf.servers[conf.CurrentApi].Select(s => s.Network).ToArray();

        GUILayout.Label("Current Network");
        int _currentNetworkIndex = conf.CurrentNetworkIndex;
        int selectedNetwork = EditorGUILayout.Popup(conf.CurrentNetworkIndex, _servers);
        conf.ChangeNetwork(selectedNetwork);

        EditorGUI.BeginDisabledGroup(true);
        EditorGUILayout.TextField("Url", conf.CurrentServer.Url);
        EditorGUILayout.Separator();

        EditorGUI.EndDisabledGroup();

        EditorUtility.SetDirty(target);
    }
}
#endif
