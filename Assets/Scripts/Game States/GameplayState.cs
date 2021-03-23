using System;
using UnityEngine;

public class GameplayState : BaseGameState
{
    [SerializeField] private GameplayUI gameplayUI;
    [SerializeField] private GameObject gameplayEnvironment;
    [SerializeField] private GoalTriggerHandler goalTrigger;

    private Canvas _gameplayCanvas;

    protected override void Awake()
    {
        base.Awake();
        _gameplayCanvas = gameplayUI.GetComponent<Canvas>();
        gameplayUI.OnMainMenuButtonClick += () => ChangeState(GameState.MainMenu);
        goalTrigger.OnGoalAreaEnter += () => ChangeState(GameState.GameOver);
    }

    protected override void HandleStateChange()
    {
        if(gameManager.CurrentState != GameState.Gameplay) return;

        ToggleUI(true);
        ToggleEnvironment(true);
    }

    private void ToggleUI(bool value) => _gameplayCanvas.enabled = value;
    private void ToggleEnvironment(bool value) => gameplayEnvironment.SetActive(value);

    protected override void ChangeState(GameState state)
    {
        ToggleUI(false);
        ToggleEnvironment(false);
        base.ChangeState(state);
    }
}