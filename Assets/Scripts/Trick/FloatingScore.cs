using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class FloatingScore : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float moveUpSpeed = 1f;
    [SerializeField] private float fadeSpeed = 1.5f;

    private Color _originalColor;

    private void Start()
    {
        _originalColor = scoreText.color;
    }

    public void Initialize(int amount)
    {
        scoreText.text = (amount >= 0 ? "+" : "") + amount.ToString();
        scoreText.color = amount >= 0 ? Color.green : Color.red;
        if (amount >= 0)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxClips[4]);
        }
        else
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxClips[5]);
        }
    }

    private void Update()
    {
        transform.position += Vector3.up * moveUpSpeed * Time.deltaTime;

        Color c = scoreText.color;
        c.a -= fadeSpeed * Time.deltaTime;
        scoreText.color = c;

        if (c.a <= 0f)
            Destroy(gameObject);
    }

}
