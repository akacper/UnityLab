// Wykorzystaj kod z listingu 1 i zmodyfikuj go tak, aby możliwe było:
// określenie w inspektorze ilości obiektów losowych do wegenerowania,
// pozycje x oraz z były pobierane adekwatnie dla obiektu platformy,
//  do której skrypt jest dołączany (zakładamy, że tak będzie),
// dodaj do swojego projektu nowe materiały, tak, aby było 5 różnych
// do wykorzystania i przydzielaj losowo materiał w trakcie tworzenia nowego obiektu.
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RandomCubesGenerator : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 1.0f;
    public int spawnCount = 10;
    int objectCounter = 0;
    // obiekt do generowania
    public GameObject block;
    public Material[] materials;
    public GameObject plane;
    private Bounds planeBounds;

    void Start()
    {
        Renderer planeRenderer = plane.GetComponent<Renderer>();
        if (planeRenderer != null)
        {
            // Get the bounds of the plane to obtain its size
            planeBounds = planeRenderer.bounds;
        }
        List<int> pozycje_x = UniqueRandomList((int)planeBounds.min.x, (int)planeBounds.max.x, spawnCount);
        List<int> pozycje_z = UniqueRandomList((int)planeBounds.min.z, (int)planeBounds.max.z, spawnCount);

        for(int i=0; i<spawnCount; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], 5, pozycje_z[i]));
        }
        foreach(Vector3 elem in positions){
            Debug.Log(elem);
        }
        materials = Resources.LoadAll("materials", typeof(Material)).Cast<Material>().ToArray();
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {
        
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywołano coroutine");
        foreach(Vector3 pos in positions)
        {
            GameObject cube = Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            if (materials.Length > 0)
            {
                Material randomMaterial = materials[UnityEngine.Random.Range(0, materials.Length)];
                // Get the Mesh Renderer component of cube
                MeshRenderer cubeRenderer = cube.GetComponent<MeshRenderer>();
                // Apply random material
                cubeRenderer.material = randomMaterial;
            }
            else
            {
                Debug.LogError("Potrzebny przynajmniej jeden materiał w folderze materials.");
            }
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }

    List<int> UniqueRandomList(int min, int max, int count) {
        HashSet<int> uniqueValues = new HashSet<int>();

        while (uniqueValues.Count < count)
        {
            int randomInt = UnityEngine.Random.Range(min, max);
            uniqueValues.Add(randomInt);
        }
        return uniqueValues.ToList();
    }
}
