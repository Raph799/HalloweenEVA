using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float sensitivity = 2.0f;

    private float rotationX = 0;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90, 90);

        transform.localRotation = Quaternion.Euler(rotationX, 90, 0);
        transform.parent.Rotate(Vector3.up * mouseX);
    }
}
