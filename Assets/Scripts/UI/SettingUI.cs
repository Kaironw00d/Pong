using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    public event Action OnMainMenuButtonClick;
    
    [SerializeField] private Button mainMenuButton;

    private void Start()
    {
        mainMenuButton.onClick.AddListener(() => OnMainMenuButtonClick?.Invoke());
    }
}