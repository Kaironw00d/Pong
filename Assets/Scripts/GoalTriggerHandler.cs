using System;
using UnityEngine;

public class GoalTriggerHandler : MonoBehaviour
{
    public Action OnGoalAreaEnter;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<ITarget>(out var target))
        {
            target.Pool.ReturnToPool(other.gameObject);
            OnGoalAreaEnter?.Invoke();
        }
    }
}