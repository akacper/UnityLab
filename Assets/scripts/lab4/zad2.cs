using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithCharacterController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 10.0f;
    private float jumpHeight = 2.0f;
    private float gravityValue = -9.81f;
    private float groundCheckDelay = 0.1f;
    private float lastTimeGrounded;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer)
        {
            lastTimeGrounded = Time.time; // Update the last time the player was grounded
            playerVelocity.y = 0f;
        }
        else if (Time.time - lastTimeGrounded < groundCheckDelay)
        {
            groundedPlayer = true; // Consider the player grounded within a short time after leaving the ground
        }

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
