// Wykorzystując możliwość dodawania obiektów czasie wykonania
//  (zobacz: https://docs.unity3d.com/Manual/InstantiatingPrefabs.html) stwórz nową scenę a w niej:
//     dodaj płaszczyznę o wymiarach 10x10
//     w momencie uruchomienia trybu play generuj 10 obiektów typu Cube, które umieszczaj losowo na płaszczyźnie, 
//     ale tak, żeby w danym miejscu nie znalazł się więcej niż jeden obiekt.

using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public Transform plane;

    public Vector3 minSpawnArea = new Vector3(-15, 0, -15);
    public Vector3 maxSpawnArea = new Vector3(15, 0, 15);
    public float spawnDelay = 0.3f;
    public int spawnCount = 10;
    private int spawnedCount = 0;

    void Start()
    {
        InvokeRepeating(nameof(NewRandomCube), 0.0f, spawnDelay);
    }

    void NewRandomCube() 
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(minSpawnArea.x, maxSpawnArea.x),
            0.5f,
            Random.Range(minSpawnArea.z, maxSpawnArea.z)
        );

        GameObject cube = Instantiate(cubePrefab, randomPosition, Quaternion.identity);
        spawnedCount++;
        Debug.Log(spawnedCount);
        if (spawnedCount == spawnCount) {
            CancelInvoke(nameof(NewRandomCube));
        }
    }
}
