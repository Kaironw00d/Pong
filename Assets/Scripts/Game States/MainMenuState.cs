using UnityEngine;

public class MainMenuState : BaseGameState
{
    [SerializeField] private MainMenuUI mainMenuUI;

    protected override void Awake()
    {
        base.Awake();
        mainMenuUI.OnPlayButtonClick += () => ChangeState(GameState.Gameplay);
        mainMenuUI.OnSettingsButtonClick += () => ChangeState(GameState.Settings);
    }

    protected override void HandleStateChange()
    {
        if (gameManager.CurrentState != GameState.MainMenu) return;
        
        ToggleUI(true);
    }

    private void ToggleUI(bool value) => mainMenuUI.gameObject.SetActive(value);

    protected override void ChangeState(GameState state)
    {
        ToggleUI(false);
        base.ChangeState(state);
    }
}