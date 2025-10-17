using System;
using TMPro;
using UnityEngine;

public class TimePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private float LimitTime = 60;
    private float _timer;

    public static event Action OnTimeLimitReached;

    private void Start()
    {
        _timer = LimitTime;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        UpdateTimeText(_timer);
        if (_timer <= 0)
        {
            OnTimeLimitReached?.Invoke();
            gameObject.SetActive(false);
        }
    }

    private void UpdateTimeText(float timer)
    {
        timeText.text = timer.ToString("F2");
    }
}
