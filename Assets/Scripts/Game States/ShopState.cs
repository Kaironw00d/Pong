using UnityEngine;

public class ShopState : BaseGameState
{
    [SerializeField] private ShopUI shopUI;

    private Canvas _shotCanvas;

    protected override void Awake()
    {
        base.Awake();
        _shotCanvas = shopUI.GetComponent<Canvas>();
        shopUI.OnMainMenuButtonClick += () => ChangeState(GameState.MainMenu);
    }

    protected override void HandleStateChange()
    {
        if(gameManager.CurrentState != GameState.Settings) return;
        
        ToggleUI(true);
    }

    private void ToggleUI(bool value) => _shotCanvas.enabled = value;
    
    protected override void ChangeState(GameState state)
    {
        ToggleUI(false);
        base.ChangeState(state);
    }
}