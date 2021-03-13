using System;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public event Action OnRepeatButtonClick;
    public event Action OnMainMenuButtonClick;
    
    [SerializeField] private Button repeatButton;
    [SerializeField] private Button mainMenuButton;

    private IAudioService _audioService;

    private void Awake()
    {
        _audioService = GameObject.FindWithTag("Audio Service").GetComponent<IAudioService>();
        
        repeatButton.onClick.AddListener(() =>
        {
            OnRepeatButtonClick?.Invoke();
            _audioService.Play(repeatButton.GetComponent<SoundSource>().soundType);
        });
        mainMenuButton.onClick.AddListener(() =>
        {
            OnMainMenuButtonClick?.Invoke();
            _audioService.Play(mainMenuButton.GetComponent<SoundSource>().soundType);
        });
    }
}