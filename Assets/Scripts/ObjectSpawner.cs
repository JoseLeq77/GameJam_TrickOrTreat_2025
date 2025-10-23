using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Objects prefabs")]
    [SerializeField] private GameObject[] obstaclePrefabs;

    [Header("Spawn probabilities")]
    [SerializeField][Range(0, 100)] private int[] probabilities;

    [Header("Spawn zone")]
    [SerializeField] private Vector2 areaSize = new Vector2(16, 9);
    [SerializeField] private Vector2 areaOffset = Vector2.zero;
    [SerializeField] private Color gizmoColor = new Color(1f, 0f, 0f, 0.3f);

    [SerializeField] private float spawnInterval = 3f;

    private float _timer = 0f;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= spawnInterval)
        {
            SpawnObstacle();
            _timer = 0f;
        }
    }

    private void SpawnObstacle()
    {
        int randomPercent = Random.Range(1, 101);
        if (obstaclePrefabs.Length == probabilities.Length && obstaclePrefabs != null && probabilities != null)
        {
            int accumulatedProbability = 0;
            for (int i = 0; i < probabilities.Length; ++i)
            {
                accumulatedProbability += probabilities[i];
                if (randomPercent <= accumulatedProbability)
                {
                    float halfWidth = areaSize.x / 2;
                    float halfHeight = areaSize.y / 2;

                    Vector3 position = transform.position + new Vector3(
                        Random.Range(-halfWidth, halfWidth) + areaOffset.x,
                        Random.Range(-halfHeight, halfHeight) + areaOffset.y,
                        0
                    );
                    Instantiate(obstaclePrefabs[i], position, obstaclePrefabs[i].transform.rotation);
                    break;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Vector3 center = transform.position + new Vector3(areaOffset.x, areaOffset.y, 0);
        Gizmos.DrawCube(center, new Vector3(areaSize.x, areaSize.y, 0.1f));
    }
}