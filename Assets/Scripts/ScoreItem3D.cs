using System;
using UnityEngine;

public class ScoreItem3D : MonoBehaviour
{
    [SerializeField] private ScoreItemInfo scoreInfo;

    public static event Action<int> OnScoreCollected;

    public void InvokeOnScoreCollectedValue()
    {
        OnScoreCollected?.Invoke(scoreInfo.scoreValue);
    }
    public static void InvokeOnScoreCollectedNegative()
    {
        OnScoreCollected?.Invoke(-1);
    }
    public int GetScoreInfo()
    {
        return scoreInfo.scoreValue;
    }
}
