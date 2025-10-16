using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [field: SerializeField] public int currentScore { get; private set; } = 0;

    public static event Action<int> OnScoreChanged;

    private void OnEnable()
    {
        ScoreItem.OnScoreCollected += AddScore;
    }
    private void OnDisable()
    {
        ScoreItem.OnScoreCollected -= AddScore;
    }

    private void AddScore(int score)
    {
        currentScore += score;
        OnScoreChanged?.Invoke(currentScore);
    }
}