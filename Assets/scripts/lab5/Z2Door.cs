//  Przygotuj prosty model drzwi przesuwanych poziomo, które 
// będą otwierane jeżeli gracz znajdzie się odpowiednio blisko jednej ze stron drzwi.
using UnityEngine;

public class MovingDoor : MonoBehaviour
{
    public float moveDistance = 2f; // Distance the platform moves horizontally
    public float moveSpeed = 3f; // Speed at which the platform moves

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool trigger = false;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + new Vector3(moveDistance, 0f, 0f);
    }

    void Update()
    {
        if (trigger)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }
    void OpenDoor()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }
    void CloseDoor()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, startPosition, step);
    }
    // void MovePlatform()
    // {
    //     float step = moveSpeed * Time.deltaTime;
    //     transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

    //     // Check if the platform has reached the target position
    //     if (Vector3.Distance(transform.position, targetPosition) < 0.01f && !trigger)
    //     {
    //         SwapTarget();
    //     }
    // }

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
            trigger = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            trigger = false;
        }
    }
}
