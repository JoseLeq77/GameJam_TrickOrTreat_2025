using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Scriptable Objects/GameData")]

public class GameData : ScriptableObject
{
    [SerializeField] private int highScore;
    [SerializeField] private int TotalScore;

    public static event Action<int> OnTotalScoreChanged;

    public int GetTotalScore()
    {
        return TotalScore;
    }
    public void SetTotalScore(int modifier)
    {
        int score = TotalScore;
        TotalScore = Mathf.Clamp(score + modifier, 0, 9999);
        OnTotalScoreChanged?.Invoke(TotalScore);
    }
}
