using System;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    public event Action OnMainMenuButtonClick;
    [SerializeField] private ScoreHandler scoreHandler;
    [SerializeField] private Text currentScoreText;
    [SerializeField] private Text maxScoreText;
    [SerializeField] private Button mainMenuButton;

    private IAudioService _audioService;

    private void Awake()
    {
        _audioService = GameObject.FindWithTag("Audio Service").GetComponent<IAudioService>();
        
        scoreHandler.OnCurrentScoreChange += value => currentScoreText.text = $"Current: {value.ToString()}";
        scoreHandler.OnMaxScoreChange += value => maxScoreText.text = $"Best: {value.ToString()}";
        mainMenuButton.onClick.AddListener(() =>
        {
            OnMainMenuButtonClick?.Invoke();
            _audioService.Play(mainMenuButton.GetComponent<SoundSource>().soundType);
        });
    }
}