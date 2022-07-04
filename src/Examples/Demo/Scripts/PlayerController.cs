using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Demo demo;
    CharacterController controller;
    public Camera cam;
    public float walkspeed;
    public float lookSpeed;
    public float jumpSpeed;
    public float gravity;

    float rotationX = 0;
    Vector3 moveDir;

    Vector3 startPosition;

    private void Start() {
        controller = GetComponent<CharacterController>();
        demo = FindObjectOfType<Demo>();
        startPosition = transform.position;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() {
        if (!controller.enabled) controller.enabled = true;
        // move
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        float curSpeedX = walkspeed * Input.GetAxis("Vertical");
        float curSpeedY = walkspeed * Input.GetAxis("Horizontal");
        float prevVertical = moveDir.y;
        moveDir = (forward * curSpeedX) + (right * curSpeedY);
        if (controller.isGrounded) {
            moveDir.y = Input.GetButton("Jump") ? jumpSpeed : 0.0f;
        } else {
            // up & down
            moveDir.y = prevVertical;
        }
        if (!controller.isGrounded) {
            moveDir.y -= gravity * Time.deltaTime;
        }

        controller.Move(moveDir * Time.deltaTime);

        // rotate
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

        // look
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -45f, 45f);
        cam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }

    private void Respawn() {
        controller.enabled = false;
        Debug.Log($"Moving from {transform.position} to {startPosition}");
        transform.position = startPosition;
        cam.transform.localRotation = Quaternion.identity;
    }
    private void OpenDoor() {
        demo.UnlockDoor();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Respawn")) {
            Respawn();
        }

        if (other.CompareTag("Finish")) {
            OpenDoor();
        }
    }
}
