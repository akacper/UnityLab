using UnityEngine;

public class MovingPlatform2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float moveDistance = 5f;
    public float waitTime = 2f;

    private bool isMovingUp = false;
    private bool isWaiting = false;
    private float initialY;
    private Rigidbody platformRigidbody;

    void Start()
    {
        initialY = transform.position.y;
        platformRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isMovingUp)
        {
            MovePlatformUp();
        }
        else if (isWaiting)
        {
            WaitAtTop();
        }
        else
        {
            MovePlatformDown();
        }
    }

    void MovePlatformUp()
    {
        platformRigidbody.MovePosition(transform.position + Vector3.up * moveSpeed * Time.deltaTime);

        if (transform.position.y >= initialY + moveDistance)
        {
            isMovingUp = false;
            isWaiting = true;
        }
    }

    void WaitAtTop()
    {
        waitTime -= Time.deltaTime;

        if (waitTime <= 0f)
        {
            isWaiting = false;
        }
    }

    void MovePlatformDown()
    {
        platformRigidbody.MovePosition(transform.position - Vector3.up * moveSpeed * Time.deltaTime);

        if (transform.position.y <= initialY)
        {
            transform.position = new Vector3(transform.position.x, initialY, transform.position.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isMovingUp = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isMovingUp = false;
        }
    }
}
