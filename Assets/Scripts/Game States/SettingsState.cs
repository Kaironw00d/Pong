using UnityEngine;

public class SettingsState : BaseGameState
{
    [SerializeField] private SettingUI settingsUI;

    protected override void Awake()
    {
        base.Awake();
        settingsUI.OnMainMenuButtonClick += () => ChangeState(GameState.MainMenu);
    }

    protected override void HandleStateChange()
    {
        if(gameManager.CurrentState != GameState.Settings) return;
        
        ToggleUI(true);
    }

    private void ToggleUI(bool value) => settingsUI.gameObject.SetActive(value);
    
    protected override void ChangeState(GameState state)
    {
        ToggleUI(false);
        base.ChangeState(state);
    }
}