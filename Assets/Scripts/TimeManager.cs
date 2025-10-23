using System;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private GameObject timePanel;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private float LimitTime = 60;
    private float _timer;
    private bool TimerisRunning = true;

    public static event Action OnTimeLimitReached;

    private void Start()
    {
        _timer = LimitTime;
    }

    private void Update()
    {
        if (TimerisRunning && _timer > 0)
        {
            _timer -= Time.deltaTime;
            UpdateTimeText(_timer);
        }
        if (_timer <= 0 && TimerisRunning)
        {
            TimerisRunning = false;
            OnTimeLimitReached?.Invoke();
            timePanel.SetActive(false);
        }
    }

    private void UpdateTimeText(float timer)
    {
        timeText.text = timer.ToString("F2");
    }
}
