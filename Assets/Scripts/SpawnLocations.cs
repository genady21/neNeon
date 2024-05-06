using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnLocations : MonoBehaviour
{
    [SerializeField] private GameObject[] emptyCells;
    [SerializeField] private GameObject[] prefabsLocations;
    public int numberOfObjectsToSpawn = 10;
    public Transform lookAtPoint;

    private void Start()
    {
        numberOfObjectsToSpawn =
            Mathf.Min(numberOfObjectsToSpawn, Mathf.Min(emptyCells.Length, prefabsLocations.Length));

        var prefabsIndices = new List<int>();
        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, prefabsLocations.Length);
            } while (prefabsIndices.Contains(randomIndex));
            prefabsIndices.Add(randomIndex);
            GameObject prefab = prefabsLocations[randomIndex];
            GameObject emptyGameObject = emptyCells[i];
            GameObject spawnedObject = Instantiate(prefab, emptyGameObject.transform.position, Quaternion.identity);
            spawnedObject.transform.LookAt(lookAtPoint);
        }

    }
}
