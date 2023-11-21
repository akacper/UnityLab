// Do obiektu Cube z zadania 2 dodaj jakiś element, który będzie wskazywał na jej kierunek forward.
// Rozbuduj skrypt z zadania 2 (ale zapisz wszystko w nowym skrypcie), 
// tak aby obiekt poruszał się 'po kwadracie' o boku 10 jednostek i docierając do wierzchołka
// wykonywał obrót o 90 stopni w kierunku kolejnego ruchu.
using UnityEngine;

public class MoveAndRotateCube : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3[] waypoints;
    public float moveSpeed = 5.0f;
    private int currentWaypointIndex = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        waypoints = new Vector3[]
        {
            new Vector3(0f, 0.5f, 0f),
            new Vector3(10f, 0.5f, 0f),
            new Vector3(10f, 0.5f, 10f),
            new Vector3(0f, 0.5f, 10f),
        };
        rb.position = waypoints[0];
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = waypoints[currentWaypointIndex];
        Vector3 newPosition = Vector3.MoveTowards(rb.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);

        if (rb.position == targetPosition)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            rb.transform.Rotate(Vector3.up, 90.0f);
        }
    }
}

