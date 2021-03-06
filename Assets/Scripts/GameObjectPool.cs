using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private readonly Queue<GameObject> _objects = new Queue<GameObject>();

    public GameObject Get()
    {
        if(_objects.Count == 0)
            AddObjects(1);
        return _objects.Dequeue();
    }

    public void ReturnToPool(GameObject objectToReturn)
    {
        objectToReturn.SetActive(false);
        _objects.Enqueue(objectToReturn);
    }

    private void AddObjects(int count)
    {
        var newObject = Instantiate(prefab);
        newObject.GetComponent<ITarget>().Pool = this;
        newObject.SetActive(false);
        _objects.Enqueue(newObject);
    }
}