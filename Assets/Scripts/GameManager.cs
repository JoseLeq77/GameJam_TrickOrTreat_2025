using UnityEngine;
public class GameManager : MonoBehaviour
{
    public void Awake()
    {
        Time.timeScale = 1f;
    }

    private void OnEnable()
    {
        TimePanel.OnTimeLimitReached += HandleTimeLimitReached;
    }

    private void OnDisable()
    {
        TimePanel.OnTimeLimitReached -= HandleTimeLimitReached;
    }

    private void HandleTimeLimitReached()
    {
        Time.timeScale = 0f;
    }
}
