using UnityEngine;
public class GameManager : MonoBehaviour
{
    public void Awake()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

    }

    private void OnEnable()
    {
        TimeManager.OnTimeLimitReached += HandleTimeLimitReached;
    }

    private void OnDisable()
    {
        TimeManager.OnTimeLimitReached -= HandleTimeLimitReached;
    }

    private void HandleTimeLimitReached()
    {
        Time.timeScale = 0f;
    }
}
