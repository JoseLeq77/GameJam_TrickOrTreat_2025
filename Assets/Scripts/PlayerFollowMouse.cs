using UnityEngine;

public class PlayerFollowMouse : MonoBehaviour
{
    [Header("Follow settings")]
    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private Camera mainCamera;

    [Header("Movement limits")]
    [SerializeField] private float minX = -2.3f;
    [SerializeField] private float maxX = 4f;

    private Transform Transform;

    private void Awake()
    {
        Transform = transform;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPosition = new Vector3(mouseWorldPos.x, Transform.position.y, Transform.position.z);
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
