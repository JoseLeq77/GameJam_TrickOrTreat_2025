using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    private enum AxisDirection
    {
        Negative = -1,
        Zero = 0,
        Positive = 1
    }

    private enum RotationMode
    {
        Disabled,
        Axis,
        Free
    }

    private enum RotationSpace
    {
        World,
        Local
    }

    [Header("Rotation settings")]
    [SerializeField] private RotationMode rotationMode = RotationMode.Disabled;
    [SerializeField] private RotationSpace rotationSpace = RotationSpace.World;

    [Header("Rotation speed (degrees/sec)")]
    [SerializeField] private float rotationSpeed = 90f;

    [Header("Axis rotation")]
    [SerializeField] private AxisDirection xDirection = AxisDirection.Zero;
    [SerializeField] private AxisDirection yDirection = AxisDirection.Zero;
    [SerializeField] private AxisDirection zDirection = AxisDirection.Zero;

    [Header("Free rotation (normalized)")]
    [SerializeField] private Vector3 customRotation = Vector3.zero;

    [Header("Freeze axis")]
    [SerializeField] private bool freezeX = false;
    [SerializeField] private bool freezeY = false;
    [SerializeField] private bool freezeZ = false;

    private void Update()
    {
        switch (rotationMode)
        {
            case RotationMode.Axis:
                RotateByAxis();
                break;
            case RotationMode.Free:
                RotateFree();
                break;
            case RotationMode.Disabled:
                break;
            default:
                break;
        }
    }

    private void RotateByAxis()
    {
        float x = freezeX ? 0 : (int)xDirection;
        float y = freezeY ? 0 : (int)yDirection;
        float z = freezeZ ? 0 : (int)zDirection;

        Vector3 rotation = new Vector3(x, y, z);
        ApplyRotation(rotation);
    }

    private void RotateFree()
    {
        Vector3 rotation = customRotation;
        rotation.x = freezeX ? 0 : rotation.x;
        rotation.y = freezeY ? 0 : rotation.y;
        rotation.z = freezeZ ? 0 : rotation.z;
        ApplyRotation(rotation);
    }

    private void ApplyRotation(Vector3 rotation)
    {
        if (rotation != Vector3.zero)
        {
            transform.Rotate(
                rotation.normalized * rotationSpeed * Time.deltaTime,
                rotationSpace == RotationSpace.World ? Space.World : Space.Self
            );
        }
    }
}