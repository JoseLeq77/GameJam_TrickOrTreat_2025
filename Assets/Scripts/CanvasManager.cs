using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject gameEndedPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private TMP_Text resultScoreText;
    [SerializeField] private TMP_Text newTotalScoreText;

    private bool isGameEnded = false;
    private bool isPaused = false;
    private bool isSettingsOpen = false;

    private void OnEnable()
    {
        TimeManager.OnTimeLimitReached += HandleTimeLimitReached;
        ScoreManager.OnScoreChanged += UpdateResultScoreText;
        GameData.OnTotalScoreChanged += UpdateNewTotalScoreText;
    }

    private void OnDisable()
    {
        TimeManager.OnTimeLimitReached -= HandleTimeLimitReached;
        ScoreManager.OnScoreChanged -= UpdateResultScoreText;
        GameData.OnTotalScoreChanged -= UpdateNewTotalScoreText;
    }

    private void Start()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxClips[3]);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameEnded)
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


    private void HandleTimeLimitReached()
    {
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.StopSFX();
        AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxClips[7]);
        SetGameEnded();
        Cursor.visible = true;
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        gameEndedPanel.SetActive(true);
    }

    private void UpdateResultScoreText(int currentScore)
    {
        resultScoreText.text = "Obtained Candies: " + currentScore.ToString();
    }

    private void UpdateNewTotalScoreText(int newTotalScore)
    {
        newTotalScoreText.text = "New Total Candies: " + newTotalScore.ToString();
    }

    public void ShowPausePanel()
    {
        AudioManager.Instance.StopSFX();
        AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxClips[8]);
        isPaused = true;
        Cursor.visible = true;
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }

    public void HidePausePanel()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxClips[3]);
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

    public void SetGameEnded()
    {
        isGameEnded = true;
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
