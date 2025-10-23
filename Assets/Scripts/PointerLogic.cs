using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PointerLogic : MonoBehaviour
{
    [SerializeField] private RouletteController rouletteController;
    [SerializeField] private TMP_Text trickText;
    [SerializeField] private TMP_Text treatText;
    [SerializeField] private TMP_Text countdownTextPrefab;
    [SerializeField] private Vector3 countdownTextOffset = new Vector3(0, -50, 0);
    [SerializeField] Color targetColor;
    [SerializeField] private string trickSceneName;
    [SerializeField] private string treatSceneName;

    private Coroutine trickColorChangeCoroutine;
    private Coroutine treatColorChangeCoroutine;

    private bool canDetect = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Trick") && !rouletteController.IsSpinning() && canDetect)
        {
            if (trickColorChangeCoroutine != null)
                StopCoroutine(trickColorChangeCoroutine);

            //AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxClips[2]);
            trickColorChangeCoroutine = StartCoroutine(ChangeColorAndLoadScene(trickText, trickSceneName));
            canDetect = false;
        }
        else if (collision.CompareTag("Treat") && !rouletteController.IsSpinning() && canDetect)
        {
            if (treatColorChangeCoroutine != null)
                StopCoroutine(treatColorChangeCoroutine);

            //AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxClips[2]);

            treatColorChangeCoroutine = StartCoroutine(ChangeColorAndLoadScene(treatText, treatSceneName));
            canDetect = false;
        }
    }

    private IEnumerator ChangeColorAndLoadScene(TMP_Text text, string sceneName, float duration = 1.0f)
    {
        yield return ChangeColorToYellow(text, duration);

        TMP_Text countdownText = Instantiate(countdownTextPrefab, text.transform.parent);
        countdownText.rectTransform.position = text.rectTransform.position + countdownTextOffset;
        AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxClips[2]);

        countdownText.text = "3";
        yield return new WaitForSeconds(1.0f);
        countdownText.text = "2";
        yield return new WaitForSeconds(1.0f);
        countdownText.text = "1";
        yield return new WaitForSeconds(1.0f);

        Destroy(countdownText.gameObject);
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.StopSFX();
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator ChangeColorToYellow(TMP_Text text, float duration = 1.0f)
    {
        Color startColor = text.color;

        float currentTime = 0f;

        while (currentTime < duration)
        {
            text.color = Color.Lerp(startColor, targetColor, currentTime / duration);
            currentTime += Time.deltaTime;
            yield return null;
        }

        text.color = targetColor;
    }
}
