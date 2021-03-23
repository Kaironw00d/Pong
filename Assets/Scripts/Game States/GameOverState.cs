using UnityEngine;

public class GameOverState : BaseGameState
{
    [SerializeField] private GameOverUI gameOverUI;

    private Canvas _gameOverCanvas;

    protected override void Awake()
    {
        base.Awake();
        _gameOverCanvas = gameOverUI.GetComponent<Canvas>();
        gameOverUI.OnRepeatButtonClick += () => ChangeState(GameState.Gameplay);
        gameOverUI.OnMainMenuButtonClick += () => ChangeState(GameState.MainMenu);
    }

    protected override void HandleStateChange()
    {
        if(gameManager.CurrentState != GameState.GameOver) return;
        
        ToggleUI(true);
    }

    private void ToggleUI(bool value) => _gameOverCanvas.enabled = value;

    protected override void ChangeState(GameState state)
    {
        ToggleUI(false);
        base.ChangeState(state);
    }
}