// Stwórz nowy obiekt na scenie imitujący płytę naciskową. 
// Po wejściu na nią (kolizja ?) gracz powinien zostać wyrzucony 
// w powietrze z trzykrotnie większą "siłą" niż w przypadku skoku.
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private float gravityValue = -9.81f;
    private float jumpHeight = 2.0f;

    private bool playerOnPlatform = false;

    void Update()
    {
        if (playerOnPlatform)
        {
            Jump();
        }
    }

    void Jump()
    {
        playerVelocity.y += Mathf.Sqrt(jumpHeight * -9.0f * gravityValue);
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerOnPlatform = true;
            controller = collision.GetComponent<CharacterController>();
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerOnPlatform = false;
        }
    }

    //// Does the same job, but uses Box Collider without Is Trigger
    // void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         playerOnPlatform = true;
    //         collision.gameObject.transform.SetParent(transform);
    //     }
    // }
    // void OnCollisionExit(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         playerOnPlatform = false;
    //         collision.gameObject.transform.SetParent(null);
    //     }
    // }
}
