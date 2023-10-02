using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 5.0f; // Fuerza del salto
    private CharacterController controller;
    private float verticalVelocity; // Variable para gestionar la velocidad vertical (salto).

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Vertical");
        float verticalInput = Input.GetAxis("Horizontal") * -1;

        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        // Aplicar la gravedad
        if (controller.isGrounded)
        {
            verticalVelocity = -1; // Restablecer la velocidad vertical cuando está en el suelo.

            // Salto
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            // Aplicar gravedad cuando no está en el suelo.
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }

        // Incorporar la velocidad vertical al movimiento
        moveDirection.y = verticalVelocity;

        controller.Move(moveDirection * speed * Time.deltaTime);
    }
}
