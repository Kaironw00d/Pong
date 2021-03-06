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

    private void Awake()
    {
        scoreHandler.OnCurrentScoreChange += value => currentScoreText.text = value.ToString();
        scoreHandler.OnMaxScoreChange += value => maxScoreText.text = value.ToString();
        mainMenuButton.onClick.AddListener(() => OnMainMenuButtonClick?.Invoke());
    }
}