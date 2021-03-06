using System;
using UnityEngine;

public class TargetGameObjectPooled : MonoBehaviour
{
    private GameObjectPool _gameObjectPool;

    private void Awake() => _gameObjectPool = GetComponent<GameObjectPool>();

    private void OnEnable()
    {
        FireTarget();
    }

    private void FireTarget()
    {
        var targetObj = _gameObjectPool.Get();
        targetObj.transform.SetParent(transform);
        targetObj.GetComponent<ITarget>().ApplySettings();
        targetObj.SetActive(true);
    }
}