using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float sensitivity = 2f;

    private float pitch = 0f;

    public Transform playerCamera;

    void Update()
    {
        // 玩家移动
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        transform.Translate(move * speed * Time.deltaTime, Space.World);

        // 鼠标控制视角
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -90f, 90f); // 限制上下视角范围

        playerCamera.localRotation = Quaternion.Euler(pitch, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }
}
