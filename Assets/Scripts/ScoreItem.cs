using System;
using UnityEngine;

public class ScoreItem : MonoBehaviour
{
    [SerializeField] private ScoreItemInfo scoreInfo;
    [SerializeField] private FloatingScore floatingScorePrefab;

    public static event Action<int> OnScoreCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            OnScoreCollected?.Invoke(scoreInfo.scoreValue);

            InstantiateFloatingScore(scoreInfo.scoreValue);
            Destroy(gameObject);
        }
    }

    private void InstantiateFloatingScore(int amount)
    {
        FloatingScore score = Instantiate(floatingScorePrefab, transform.position, Quaternion.identity);
        score.Initialize(amount);
    }
}
