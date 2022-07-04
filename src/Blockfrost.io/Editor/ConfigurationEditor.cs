using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Blockfrost.Configuration))]
public class ConfigurationEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        var conf = target as Blockfrost.Configuration;
        var _servers = conf.servers.Select(s => s.Name).ToArray();

        GUILayout.Label("Current server:");
        int _currentServerIndex = conf.CurrentServerIndex;
        int selected = EditorGUILayout.Popup(conf.CurrentServerIndex, _servers);
        conf.ChangeServer(selected);

        EditorGUI.BeginDisabledGroup(true);
        EditorGUILayout.TextField("Url", conf.CurrentServer.Url);
        EditorGUILayout.Separator();
        // TODO OAInfo
        EditorGUI.EndDisabledGroup();

        EditorUtility.SetDirty(target);
    }
}
