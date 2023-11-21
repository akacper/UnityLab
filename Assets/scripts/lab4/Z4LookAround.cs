// Dodaj do skryptu LookAround ograniczenie obracania kamery 
// do -90 i +90 stopni góra-dół (sprawdź metodę Mathf.Clamp z API Unity).
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public Transform player;
    public float sensitivity = 200f;
    private float maxVerticalLook = 90f;

    private float rotationX = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // rotate around Y axis
        player.Rotate(Vector3.up * mouseXMove);

        // accumulate rotation values from mouse
        rotationX -= mouseYMove;
        // limit values for rotationX (up-down camera movement)
        rotationX = Mathf.Clamp(rotationX, -maxVerticalLook, maxVerticalLook);

        // rotate around X axis
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }
}
