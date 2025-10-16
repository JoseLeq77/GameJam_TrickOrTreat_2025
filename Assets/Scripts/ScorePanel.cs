using TMPro;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private void OnEnable()
    {
        ScoreManager.OnScoreChanged += UpdateScoreText;
    }
    private void OnDisable()
    {
        ScoreManager.OnScoreChanged -= UpdateScoreText;
    }

    private void UpdateScoreText(int currentScore)
    {
        scoreText.text = currentScore.ToString();
    }
}