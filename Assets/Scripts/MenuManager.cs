using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Transform[] viewPositions;
    [SerializeField] private float moveDuration = 0.5f;
    [SerializeField] private Ease easeType = Ease.InOutQuad;
    
    private Camera _mainCamera;

    private void Awake()
    {
        Time.timeScale = 1f;
        _mainCamera = Camera.main;
    }

    private void Start()
    {
        AudioManager.Instance.PlayMusic(AudioManager.Instance.musicClips[0]);
    }

    public void ChangeScene(string scene)
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxClips[8]);
        DOTween.Kill(_mainCamera.transform);
        AudioManager.Instance.StopMusic();
        SceneManager.LoadScene(scene);
    }

    public void ToSettingsPosition()
    {
        if (_mainCamera == null)
            _mainCamera = Camera.main;
            
        if (viewPositions == null || viewPositions.Length == 0 || viewPositions[0] == null)
        {
            return;
        }
        
        _mainCamera.transform.DOMove(viewPositions[0].position, moveDuration)
            .SetEase(easeType);
        AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxClips[8]);

        AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxClips[0]);
    }

    public void ToMainMenuPosition()
    {
        if (_mainCamera == null)
            _mainCamera = Camera.main;
            
        if (viewPositions == null || viewPositions.Length <= 1 || viewPositions[1] == null)
        {
            return;
        }
        
        _mainCamera.transform.DOMove(viewPositions[1].position, moveDuration)
            .SetEase(easeType);
        AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxClips[8]);

        AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxClips[0]);

    }

    public void ExitGame()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxClips[8]);

        Debug.Log("Saliendo del juego");
        Application.Quit();
    }
}
