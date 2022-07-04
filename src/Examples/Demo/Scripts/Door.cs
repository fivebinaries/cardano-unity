using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour {
    public Vector3 open;
    public Vector3 closed;
    public float openingTime;
    public bool isOpen;
    public bool isOpening;

    private void Start() {
        closed = transform.position;
    }

    public void Open() {
        StartCoroutine(OpenClose(true));
        StartCoroutine(OpenClose(false, initialDelay: openingTime * 6.0f)); ;
    }

    IEnumerator OpenClose(bool opening, float initialDelay = 0.0f) {
        yield return new WaitForSeconds(initialDelay);
        if (isOpening) yield break;
        isOpening = true;
        var target = opening ? open : closed;
        var origin = transform.position;
        float elapsed = 0.0f;
        while (elapsed < openingTime) {
            transform.position = Vector3.Lerp(origin, target, (elapsed / openingTime));
            elapsed += Time.deltaTime;
            yield return null;
        }
        isOpen = !isOpen;
        isOpening = false;
    }
}
