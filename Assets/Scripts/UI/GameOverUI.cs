using System;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public event Action OnRepeatButtonClick;
    public event Action OnMainMenuButtonClick;
    
    [SerializeField] private Button repeatButton;
    [SerializeField] private Button mainMenuButton;

    private void Start()
    {
        repeatButton.onClick.AddListener(() => OnRepeatButtonClick?.Invoke());
        mainMenuButton.onClick.AddListener(() => OnMainMenuButtonClick?.Invoke());
    }
}