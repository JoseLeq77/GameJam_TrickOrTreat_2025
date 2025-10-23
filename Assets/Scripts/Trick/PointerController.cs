using UnityEngine;
using UnityEngine.InputSystem;

public class PointerController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject crosshair;

    
    [Header("MovementLimits")]
    [SerializeField] private float horizontalLimit = 8f;
    [SerializeField] private float verticalLimit = 4.5f;
    
    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
    private void Start()
    {
        AudioManager.Instance.PlayMusic(AudioManager.Instance.musicClips[4]);
    }

    private void OnDestroy()
    {
        Cursor.visible = true;
    }

    private void Update()
    {
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.x = Mathf.Clamp(mouseWorldPos.x, -horizontalLimit, horizontalLimit);
        mouseWorldPos.y = Mathf.Clamp(mouseWorldPos.y, -verticalLimit, verticalLimit);
        mouseWorldPos.z = 0f;

        crosshair.transform.position = Vector3.Lerp(crosshair.transform.position, mouseWorldPos, smoothSpeed * Time.deltaTime);
        transform.position = mouseWorldPos;
    }
}