using System.Collections.Generic;
using UnityEngine;

public class RemoveSectorAndLocation : MonoBehaviour
{
    private SpawnNomberSector _spawnNomberSector;
    private Stack<GameObject> _gameObjectsStack;
    
    public void RemoveTopNomberSector()
    {
        if (_gameObjectsStack.Count > 0)
        {
            var topObject = _gameObjectsStack.Pop();
            Destroy(topObject);
            UpdateVisual();
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
    public void SetGameObjectStack(Stack<GameObject> gameObjectsStack)
    {
        _gameObjectsStack = gameObjectsStack;
    }
}
