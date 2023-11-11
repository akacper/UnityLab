using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float turnSmoothTime = 0.5f;
    public float jumpForce = 8f;
    private float turnSmoothVelocity;
    private float ySpeed;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (characterController.isGrounded)
        {
            ySpeed = -0.5f; // Reset vertical speed when grounded

            // Jumping
            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpForce;
            }
        }
        else
        {
            // Apply gravity when not grounded
            ySpeed += Physics.gravity.y * Time.deltaTime;
        }

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            characterController.Move((moveDir.normalized * speed + new Vector3(0, ySpeed, 0)) * Time.deltaTime);
        }
    }
}
