using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnNomberSector : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabNomberSectors;
    [SerializeField] private Transform _spawnPoint;
    private Stack<GameObject> _gameObjectsStack = new Stack<GameObject>();

    private void Start()
    {
        SpawnObjects();
        UpdateVisual();
    }

    private void SpawnObjects()
    {
        List<GameObject> remainingObjects = new List<GameObject>(_prefabNomberSectors);

        while (remainingObjects.Count > 0)
        {
            int index = Random.Range(0, remainingObjects.Count);
            GameObject objectToSpawn = remainingObjects[index];
            GameObject obj = Instantiate(objectToSpawn, _spawnPoint.position, Quaternion.identity);
            remainingObjects.RemoveAt(index);
            obj.SetActive(false);
            _gameObjectsStack.Push(obj);
        }
    }

    private void UpdateVisual()
    {
        foreach (var obj    in _gameObjectsStack)
        {
            obj.SetActive(false);
        }

        if (_gameObjectsStack.Count > 0)
        {
            GameObject topObject = _gameObjectsStack.Peek();
            topObject.SetActive(true);
        }
    }

    public void RemoveTopNomberSector()
    {
        if (_gameObjectsStack.Count > 0)
        {
            GameObject topObject = _gameObjectsStack.Pop();
            Destroy(topObject);
            UpdateVisual();
        }
    }
    
}

