using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private TMP_Text totalScoreText;

    public static event Action OnScoreUpdated;

    private void OnEnable()
    {
        OnScoreUpdated += UpdateTotalScoreUI;
    }

    private void OnDisable()
    {
        OnScoreUpdated -= UpdateTotalScoreUI;
    }

    private void Start()
    {
        UpdateTotalScoreUI();
    }

    public void UpdateTotalScoreUI()
    {
        totalScoreText.text = gameData.GetTotalScore().ToString();
    }

    public void InvokeOnScoreUpdate()
    {
        OnScoreUpdated?.Invoke();
    }
}
