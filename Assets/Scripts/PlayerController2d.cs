using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2d : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float moveSpeed = 5f;

    private Vector2 _inputVector;
    private Rigidbody2D _rb2d;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rb2d.linearVelocity = new Vector2(_inputVector.x * moveSpeed, _inputVector.y * moveSpeed);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _inputVector = context.ReadValue<Vector2>();
    }

}
