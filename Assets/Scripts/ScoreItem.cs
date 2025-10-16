using System;
using UnityEngine;

public class ScoreItem : MonoBehaviour
{
    [SerializeField] private ScoreItemInfo scoreInfo;

    public static event Action<int> OnScoreCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnScoreCollected?.Invoke(scoreInfo.scoreValue);
            Destroy(gameObject);
        }
    }
}
