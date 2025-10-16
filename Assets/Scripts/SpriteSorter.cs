using UnityEngine;

public class SpriteSorter : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Transform Transform;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Transform = transform;
    }

    private void LateUpdate()
    {
        spriteRenderer.sortingOrder = Mathf.FloorToInt(-Transform.position.y * 100f);
    }
}
