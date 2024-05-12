using System.Collections.Generic;
using UnityEngine;

public class SpawnLocations : MonoBehaviour
{
    [SerializeField] private GameObject[] emptyCells;
    [SerializeField] private GameObject[] prefabsLocations;
    private int numberOfObjectsToSpawn = 10;
    public Transform lookAtPoint;

    private void Start()
    {
        numberOfObjectsToSpawn =
            Mathf.Min(numberOfObjectsToSpawn, Mathf.Min(emptyCells.Length, prefabsLocations.Length));

        var prefabsIndices = new List<int>();
        for (var i = 0; i < numberOfObjectsToSpawn; i++)
        {
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, prefabsLocations.Length);
            } while (prefabsIndices.Contains(randomIndex));

            prefabsIndices.Add(randomIndex);
            var prefab = prefabsLocations[randomIndex];
            var emptyGameObject = emptyCells[i];
            var spawnedObject = Instantiate(prefab, emptyGameObject.transform.position, Quaternion.identity);
            spawnedObject.transform.LookAt(lookAtPoint);
        }
    }
}