using UnityEngine;

public abstract class BaseGameState : MonoBehaviour
{
    protected GameManager gameManager;
    protected virtual void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.OnStateChange += HandleStateChange;
    }

    protected virtual void HandleStateChange()
    {
    }
    
    protected virtual void ChangeState(GameState state)
    {
        gameManager.SetState(state);
    }
}