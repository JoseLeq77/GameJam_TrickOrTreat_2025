using UnityEngine;

public class ConstantMovement : MonoBehaviour
{
    private enum AxisDirection
    {
        Negative = -1,
        Zero = 0,
        Positive = 1
    }

    private enum MovementMode
    {
        Disabled,
        Axis,
        Free
    }

    [Header("Movement settings")]
    [SerializeField] private MovementMode movementMode = MovementMode.Disabled;

    [Header("Movement speed (units/sec)")]
    [SerializeField] private float speed = 5f;

    [Header("Lifetime")]
    [SerializeField] private bool hasLifetime = true;
    [SerializeField] private float lifetime = 10f;

    [Header("Axis movement")]
    [SerializeField] private AxisDirection xDirection = AxisDirection.Zero;
    [SerializeField] private AxisDirection yDirection = AxisDirection.Zero;
    [SerializeField] private AxisDirection zDirection = AxisDirection.Zero;

    [Header("Free movement")]
    [SerializeField] private Vector3 customMovement = Vector3.zero;

    [Header("Freeze axis")]
    [SerializeField] private bool freezeX = false;
    [SerializeField] private bool freezeY = false;
    [SerializeField] private bool freezeZ = false;

    private void Start()
    {
        if (hasLifetime && movementMode != MovementMode.Disabled)
        {
            Destroy(gameObject, lifetime);
        }
    }

    private void Update()
    {
        switch (movementMode)
        {
            case MovementMode.Axis:
                MoveByAxis();
                break;
            case MovementMode.Free:
                MoveFree();
                break;
            case MovementMode.Disabled:
                break;
            default:
                break;
        }
    }

    private void MoveByAxis()
    {
        float x = freezeX ? 0 : (int)xDirection;
        float y = freezeY ? 0 : (int)yDirection;
        float z = freezeZ ? 0 : (int)zDirection;

        Vector3 direction = new Vector3(x, y, z);
        ApplyMovement(direction);
    }

    private void MoveFree()
    {
        Vector3 movement = customMovement;
        movement.x = freezeX ? 0 : movement.x;
        movement.y = freezeY ? 0 : movement.y;
        movement.z = freezeZ ? 0 : movement.z;
        ApplyMovement(movement);
    }

    private void ApplyMovement(Vector3 movement)
    {
        if (movement != Vector3.zero)
        {
            transform.position += movement.normalized * speed * Time.deltaTime;
        }
    }
}