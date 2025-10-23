using UnityEngine;

public class RouletteController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 360f;
    [SerializeField] private float timerToStop = 5f;
    [SerializeField] bool isSpinning = true;

    private void Start()
    {
        Cursor.visible = false;
        AudioManager.Instance.PlayMusic(AudioManager.Instance.musicClips[2]);
        AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxClips[1]);
        transform.Rotate(Vector3.forward * Random.Range(0f, 360f), Space.World);
        timerToStop = Random.Range(3f, 5f);
    }

    private void Update()
    {
        timerToStop -= Time.deltaTime;
        if (isSpinning)
        {
            Vector3 rotation = Vector3.forward;
            ApplyRotation(rotation);
        }
        if (timerToStop <= 0)
        {
            rotationSpeed -= rotationSpeed * Time.deltaTime;
        }
        if (rotationSpeed <= 1f)
        {
            rotationSpeed = 0f;
            isSpinning = false;
        }
    }
    private void ApplyRotation(Vector3 rotation)
    {
        if (rotation != Vector3.zero)
        {
            transform.Rotate(rotation.normalized * rotationSpeed * Time.deltaTime, Space.World);
        }
    }

    private void OnEnable()
    {
        isSpinning = true;
    }

    private void OnDestroy()
    {
        AudioManager.Instance.StopMusic();
    }

    public bool IsSpinning()
    {
        return isSpinning;
    }
}
