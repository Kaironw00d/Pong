using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public static event Action OnTargetCollision;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<ITarget>(out var target))
            OnTargetCollision?.Invoke();
    }
}