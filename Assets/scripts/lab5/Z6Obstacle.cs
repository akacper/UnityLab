// Stwórz nowy obiekt, który będzie obiektem przeszkodą, dodaj do niego tag. 
// Stwórz z tego obiektu prefabrykat i dodaj kilka instancji prefabrykatu 
// do sceny w różnych miejscach poziomu. Dodaj do obiektu gracza skrypt, 
// który będzie zawierał kod sprawdzający czy doszło do kontaktu pomiędzy 
// graczem a przeszkodą (można wyszukiwać obiekty za pomocą tagu). 
// Wyświetlaj komunikat o rozpoczęciu kontaktu w konsoli.

// (zadanie rozwiazane w lab4/Z2MoveWithCharacterController oraz drugie rozwiazanie tutaj)
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private bool playerOnPlatform = false;

    void Update()
    {
        if (playerOnPlatform)
        {
            // Debug.Log("Wykryto dotkniecie przeszkody (skrypt przeszkody).");
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerOnPlatform = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerOnPlatform = false;
        }
    }
}
