using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Console : MonoBehaviour {

    public Transform panel;
    public int keepLines;
    private Text console;

    private Queue<string> lines;
    // Start is called before the first frame update
    void Start() {
        console = panel.GetComponentInChildren<Text>();
        lines = new Queue<string>(keepLines);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.C)) {
            panel.gameObject.SetActive(!panel.gameObject.activeSelf);
        }
    }

    public void Log(string message, string data) {
        if (lines.Count >= keepLines) lines.Dequeue();
        lines.Enqueue($"<b>{message}</b> {data}");
        console.text = string.Join("\n", lines);
    }
}
