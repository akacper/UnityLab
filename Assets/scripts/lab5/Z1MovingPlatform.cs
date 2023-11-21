// Przygotuj skrypt i przykład platformy poruszającej się horyzontalnie 
// w momencie, w którym gracz na nią wejdzie. Platforma ma ustalony punkt 
// docelowy i po dotarciu do niego powinna wrócić do miejsca początkowego.
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveDistance = 4f; // Distance the platform moves horizontally
    public float moveSpeed = 4f; // Speed at which the platform moves

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool playerOnPlatform = false;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + new Vector3(moveDistance, 0f, 0f);
    }

    void FixedUpdate()
    {
        if (playerOnPlatform)
        {
            MovePlatform();
        }
    }

    void MovePlatform()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        // Check if the platform has reached the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            SwapTarget();
        }
    }

    void SwapTarget()
    {
        Vector3 temp = startPosition;
        startPosition = targetPosition;
        targetPosition = temp;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerOnPlatform = true;
            collision.gameObject.transform.SetParent(transform);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerOnPlatform = false;
            collision.gameObject.transform.SetParent(null);
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
