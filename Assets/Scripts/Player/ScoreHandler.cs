using System;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public event Action<int> OnCurrentScoreChange;
    public event Action<int> OnMaxScoreChange;

    [SerializeField] private int currentScore;
    private int CurrentScore
    {
        get => currentScore;
        set
        {
            currentScore = value;
            OnCurrentScoreChange?.Invoke(currentScore);
            if (currentScore > MaxScore)
                MaxScore = currentScore;
        }
    }
    [SerializeField] private int maxScore;
    private int MaxScore
    {
        get => maxScore;
        set
        {
            maxScore = value;
            PlayerPrefs.SetInt("MaxScore", maxScore);
            OnMaxScoreChange?.Invoke(maxScore);
        }
    }
    
    private void Awake()
    {
        CollisionHandler.OnTargetCollision += IncreaseCurrentScore;
    }

    private void OnEnable()
    {
        CurrentScore = 0;
        MaxScore = PlayerPrefs.GetInt("MaxScore", 0);
    }

    private void IncreaseCurrentScore() => CurrentScore++;
}