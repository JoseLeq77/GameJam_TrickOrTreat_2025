using UnityEngine;

public class CanvasMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject totalScoreText;
    [SerializeField] private GameObject settingsPanel;

    private bool isPaused = false;
    private bool isSettingsOpen = false;

    private void Start()
    {
        AudioManager.Instance.PlayMusic(AudioManager.Instance.musicClips[1]);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                ShowPausePanel();
            }
            else if (isSettingsOpen)
            {
                HideSettingsPanel();
            }
            else
            {
                HidePausePanel();
            }
        }
    }

    public void ShowPausePanel()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxClips[8]);

        isPaused = true;
        Cursor.visible = true;
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }

    public void HidePausePanel()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxClips[8]);

        isPaused = false;
        Cursor.visible = false;
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;

    }

    public void ShowSettignsPanel()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxClips[8]);

        isSettingsOpen = true;
        pausePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void HideSettingsPanel()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxClips[8]);

        isSettingsOpen = false;
        settingsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public bool IsPaused()
    {
        return isPaused;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}
