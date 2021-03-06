using UnityEngine;

public class MainMenuState : BaseGameState
{
    [SerializeField] private MainMenuUI mainMenuUI;
    
    private Canvas _mainMenuCanvas;

    protected override void Awake()
    {
        base.Awake();
        _mainMenuCanvas = mainMenuUI.GetComponent<Canvas>();
        mainMenuUI.OnPlayButtonClick += () => ChangeState(GameState.Gameplay);
        mainMenuUI.OnSettingsButtonClick += () => ChangeState(GameState.Settings);
        mainMenuUI.OnQuitButtonClick += Application.Quit;
    }

    protected override void HandleStateChange()
    {
        if (gameManager.CurrentState != GameState.MainMenu) return;
        
        ToggleUI(true);
    }

    private void ToggleUI(bool value) => _mainMenuCanvas.enabled = value;

    protected override void ChangeState(GameState state)
    {
        ToggleUI(false);
        base.ChangeState(state);
    }
}