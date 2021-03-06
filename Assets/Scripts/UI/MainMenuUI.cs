using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public event Action OnPlayButtonClick;
    public event Action OnSettingsButtonClick;
    
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;

    private void Start()
    {
        playButton.onClick.AddListener(() => OnPlayButtonClick?.Invoke());
        settingsButton.onClick.AddListener(() => OnSettingsButtonClick?.Invoke());
    }
}