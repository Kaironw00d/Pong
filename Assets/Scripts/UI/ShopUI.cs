using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public event Action OnMainMenuButtonClick;
    
    [SerializeField] private Button mainMenuButton;

    private IAudioService _audioService;
    private SoundSource[] _soundSources;

    private void Awake()
    {
        _audioService = GameObject.FindWithTag("Audio Service").GetComponent<IAudioService>();
        _soundSources = GetComponentsInChildren<SoundSource>(true);
        
        for (var i = 0; i < _soundSources.Length; i++)
        {
            var soundSource = _soundSources[i];
            soundSource.playSoundDelegate += () => _audioService.Play(soundSource.soundType);
        }
        
        mainMenuButton.onClick.AddListener(() => OnMainMenuButtonClick?.Invoke());
    }
}