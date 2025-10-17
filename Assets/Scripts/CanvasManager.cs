using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject gameEndedPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject settingsPanel;

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
        gameEndedPanel.SetActive(true);
    }

    public void ShowPausePanel()
    {
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }

    public void HidePausePanel()
    {
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;

    }

    public void ShowSettignsPanel()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void HideSettingsPanel()
    {
        settingsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

}
