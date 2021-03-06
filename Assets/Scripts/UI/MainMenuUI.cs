using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public event Action OnPlayButtonClick;
    public event Action OnSettingsButtonClick;
    public event Action OnQuitButtonClick;
    
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;

    private void Start()
    {
        playButton.onClick.AddListener(() => OnPlayButtonClick?.Invoke());
        settingsButton.onClick.AddListener(() => OnSettingsButtonClick?.Invoke());
        quitButton.onClick.AddListener(() => OnQuitButtonClick?.Invoke());
    }
}