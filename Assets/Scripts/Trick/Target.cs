using UnityEngine;

public class Target : MonoBehaviour
{
    #region Variables
    [Header("Configuración")]
    [SerializeField] private int pointValue = 10;
    
    [Header("Movimiento")]
    [SerializeField] private MovementType movementType = MovementType.Static;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float amplitude = 2f;
    [SerializeField] private float rotationRadius = 2f;
    [SerializeField] private int targetLifetime = 2;


    private Vector3 _startPosition;
    private float _movementTimer;

    #endregion

    #region Enums
    public enum MovementType
    {
        Static,
        Horizontal,
        Vertical,
        Circular
    }
    #endregion

    #region Unity Methods
    private void Start()
    {
        _startPosition = transform.position;
        Destroy(gameObject, targetLifetime);
    }

    private void Update()
    {
        ApplyMovement();
    }
    #endregion

    #region Methods
    public void OnHit()
    {
        Destroy(gameObject);
    }
    
    private void ApplyMovement()
    {
        _movementTimer += Time.deltaTime;
        
        switch (movementType)
        {
            case MovementType.Static:
                break;
                
            case MovementType.Horizontal:
                transform.position = _startPosition + new Vector3(Mathf.Sin(_movementTimer * speed) * amplitude, 0, 0);
                break;
                
            case MovementType.Vertical:
                transform.position = _startPosition + new Vector3(0, Mathf.Sin(_movementTimer * speed) * amplitude, 0);
                break;
                
            case MovementType.Circular:
                float x = Mathf.Sin(_movementTimer * speed) * rotationRadius;
                float y = Mathf.Cos(_movementTimer * speed) * rotationRadius;
                transform.position = _startPosition + new Vector3(x, y, 0);
                break;
        }
    }
    #endregion 
}