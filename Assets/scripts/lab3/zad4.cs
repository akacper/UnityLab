// Dodaj nową scenę do swojego projektu. Stwórz obiekt, który będzie obiektem gracza 
// (cube, sphere, cokolwiek). Dodaj do sceny płaszczyznę o wymiarach 20x20 jednostek.
// Dodaj możliwość przemieszczania obiektu po płaszczyźnie.
using UnityEngine;

public class MoveSphere : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}


