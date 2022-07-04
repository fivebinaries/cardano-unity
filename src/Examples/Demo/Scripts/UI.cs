using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Transform intro;
    public Transform error;

    void Start() {
        intro.gameObject.SetActive(true);
    }

    public void DisableIntro() {
        intro.gameObject.SetActive(false);
    }

    public void Error(string message) {
        var errorText = error.GetComponentInChildren<Text>();
        errorText.text = $"<b>ERROR</b> {message}";
        error.gameObject.SetActive(true);
    }
}
