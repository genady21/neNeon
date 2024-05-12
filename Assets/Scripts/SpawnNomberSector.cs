using System.Collections.Generic;
using UnityEngine;

public class SpawnNomberSector : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabNomberSectors;
    [SerializeField] private Transform _spawnPoint;
    private readonly Stack<GameObject> _gameObjectsStack = new();
    private RemoveSectorAndLocation _removeSectorAndLocation;

    private void Start()
    {
        _removeSectorAndLocation = GetComponent<RemoveSectorAndLocation>();
        _removeSectorAndLocation.SetGameObjectStack(_gameObjectsStack);
        SpawnObjects();
        UpdateVisual();
    }

    private void SpawnObjects()
    {
        var remainingObjects = new List<GameObject>(_prefabNomberSectors);

        while (remainingObjects.Count > 0)
        {
            var index = Random.Range(0, remainingObjects.Count);
            var objectToSpawn = remainingObjects[index];
            var obj = Instantiate(objectToSpawn, _spawnPoint.position, Quaternion.identity);
            remainingObjects.RemoveAt(index);
            obj.SetActive(false);
            _gameObjectsStack.Push(obj);
        }
    }

    public void UpdateVisual()
    {
        foreach (var obj in _gameObjectsStack) obj.SetActive(false);

        if (_gameObjectsStack.Count > 0)
        {
            var topObject = _gameObjectsStack.Peek();
            topObject.SetActive(true);
        }
    }
}