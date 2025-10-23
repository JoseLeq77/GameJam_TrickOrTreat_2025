using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [field: SerializeField] public int currentScore { get; private set; } = 0;
    [SerializeField] private GameData gameData;

    public static event Action<int> OnScoreChanged;

    private void OnEnable()
    {
        TimeManager.OnTimeLimitReached += UpdateTotalScore;
        ScoreItem.OnScoreCollected += AddScore;
        ScoreItem3D.OnScoreCollected += AddScore;
    }
    private void OnDisable()
    {
        ScoreItem.OnScoreCollected -= AddScore;
        TimeManager.OnTimeLimitReached -= UpdateTotalScore;
        ScoreItem3D.OnScoreCollected -= AddScore;
    }

    private void AddScore(int score)
    {
        currentScore += score;
        OnScoreChanged?.Invoke(currentScore);
    }

    private void UpdateTotalScore()
    {
        gameData.SetTotalScore(currentScore);
    }
}