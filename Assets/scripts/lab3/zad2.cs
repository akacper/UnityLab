// Stwórz nową scenę. Dodaj do niej obiekt typu Cube o wymiarach (2, 1, 1).
// Napisz skrypt, z publicznym polem speed (float), który będzie przemieszczał obiekt wzdłóż osi x o 10 jednostek 
// i w momencie wykonania takiego przesunięcia będzie wykonywał ruch powrotny.
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 startPosition = new Vector3(0f, 0.5f, 0f);
    public Vector3 endPosition = new Vector3(10f, 0.5f, 0f);
    public float moveSpeed = 5.0f;
    private bool movingForward = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.position = startPosition;
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = movingForward ? endPosition : startPosition;
        Vector3 newPosition = Vector3.MoveTowards(rb.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);

        if (rb.position == targetPosition)
        {
            movingForward = !movingForward;
        }
    }
}
