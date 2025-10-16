using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Objects prefabs")]
    [SerializeField] private GameObject[] obstaclePrefabs;

    [Header("Spawn probabilities")]
    [SerializeField][Range(0, 100)] private int[] probabilities;

    [Header("Spawn zone")]
    [SerializeField] private Vector3 spawnAreaMin;
    [SerializeField] private Vector3 spawnAreaMax;

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
                    Vector3 spawnPos = new Vector3(
                        Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                        Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                        Random.Range(spawnAreaMin.z, spawnAreaMax.z)
                    );
                    Instantiate(obstaclePrefabs[i], spawnPos, obstaclePrefabs[i].transform.rotation);
                    break;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 center = (spawnAreaMin + spawnAreaMax) / 2f;

        Vector3 size = new Vector3(
            Mathf.Abs(spawnAreaMax.x - spawnAreaMin.x),
            Mathf.Abs(spawnAreaMax.y - spawnAreaMin.y),
            Mathf.Abs(spawnAreaMax.z - spawnAreaMin.z)
        );

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(center, size);
    }
}