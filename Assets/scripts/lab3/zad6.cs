// Korzystając z przykładu w dokumentacji UNITY dostępnej pod adresem https://docs.unity3d.com/ScriptReference/Mathf.SmoothDamp.html 
// zaimplementuj go dla dwóch obiektów na swojej scenie i
// przetestuj  zmieniając położenie w trybie game obiektu, 
// który 'jest śledzony'. Przetestuj również metodę Mathf.Lerp.

using UnityEngine;

public class Example6 : MonoBehaviour
{
    // Smooth towards the height of the target

    public Transform target;
    float smoothTime = 0.3f;
    float yVelocity = 0.0f;

    void Update()
    {
        float newPosition = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelocity, smoothTime);
        transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
    }
}

// Z użyciem Mathf.Lerp
// public class Example6 : MonoBehaviour
// {
//     public Transform target;
//     public float smoothTime = 0.3f;

//     void Update()
//     {
//         float t = Mathf.Clamp01(smoothTime * Time.deltaTime);
//         float newPosition = Mathf.Lerp(transform.position.y, target.position.y, t);
//         transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
//     }
// }
