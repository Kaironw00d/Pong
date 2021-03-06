using System;
using UnityEngine;

public enum GameState
{
    Boot,
    MainMenu,
    Settings,
    Gameplay,
    GameOver
}

public class GameManager : MonoBehaviour
{
    public delegate void OnStateChangeHandler();
    public event OnStateChangeHandler OnStateChange;

    public GameState CurrentState { get; private set; }

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    private void Start() => SetState(GameState.MainMenu);

    public void SetState(GameState state)
    {
        CurrentState = state;
        OnStateChange?.Invoke();
    }
}
