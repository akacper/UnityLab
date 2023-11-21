// Z przykładów z zajęć oraz zadania 1 przygotuj skrypt, który 
// pozwoli na obsłużenie platformy, która może poruszać się dowolnie 
// w przestrzeni od punktu do punktu. Punkty (w postaci obiektu Vector3) 
// są przechowywane w dowolnej wybranej kolekcji. Wypróbuj możliwość 
// dodawania kolejnych waypointów poprzez panel Inspektor. 
// Platforma porusza się od pierwszego do kolejnego punktu 
// i jak dotrze do ostatniego punktu, zawraca (czyli podąża tą samą drogą w przeciwnym kierunku).
using UnityEngine;

public class MovingPlatformVector : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed at which the platform moves

    [SerializeField] Vector3 startPosition;
    [SerializeField] Vector3 targetPosition;
    private bool playerOnPlatform = false;

    void Start()
    {
        startPosition = transform.position;
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
}
