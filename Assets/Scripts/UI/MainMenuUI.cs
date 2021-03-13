using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public event Action OnPlayButtonClick;
    public event Action OnSettingsButtonClick;
    public event Action OnQuitButtonClick;
    
    [SerializeField] private Button playButton;
    [SerializeField] private Button shopButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Toggle musicToggle;
    [SerializeField] private Toggle soundsToggle;

    private IAudioService _audioService;

    private void Awake()
    {
        _audioService = GameObject.FindWithTag("Audio Service").GetComponent<IAudioService>();

        playButton.onClick.AddListener(() =>
        {
            OnPlayButtonClick?.Invoke();
            _audioService.Play(playButton.GetComponent<SoundSource>().soundType);
        });
        shopButton.onClick.AddListener(() =>
        {
            OnSettingsButtonClick?.Invoke();
            _audioService.Play(shopButton.GetComponent<SoundSource>().soundType);
        });
        quitButton.onClick.AddListener(() =>
        {
            OnQuitButtonClick?.Invoke();
            _audioService.Play(quitButton.GetComponent<SoundSource>().soundType);
        });
        musicToggle.onValueChanged.AddListener(value => _audioService.ToggleMusic(value));
        soundsToggle.onValueChanged.AddListener(value => _audioService.ToggleSounds(value));
    }
}