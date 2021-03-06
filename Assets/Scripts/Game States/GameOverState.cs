using UnityEngine;

public class GameOverState : BaseGameState
{
    [SerializeField] private GameOverUI gameOverUI;

    protected override void Awake()
    {
        base.Awake();
        gameOverUI.OnRepeatButtonClick += () => ChangeState(GameState.Gameplay);
        gameOverUI.OnMainMenuButtonClick += () => ChangeState(GameState.MainMenu);
    }

    protected override void HandleStateChange()
    {
        if(gameManager.CurrentState != GameState.GameOver) return;
        
        ToggleUI(true);
    }

    private void ToggleUI(bool value) => gameOverUI.gameObject.SetActive(value);

    protected override void ChangeState(GameState state)
    {
        ToggleUI(false);
        base.ChangeState(state);
    }
}