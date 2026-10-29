using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstaclePrefabs;

    [SerializeField]
    private Transform obstacleContainer;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private int obstacleCount = 10;

    [SerializeField]
    private float minPosition = -8f;

    [SerializeField]
    private float maxPosition = 8f;

    [SerializeField]
    private float minDistanceFromPlayer = 3f;

    [SerializeField]
    private float checkRadius = 1.2f;

    [SerializeField]
    private LayerMask obstacleLayer;

    private void Start()
    {
        SpawnObstacles();
    }

    private void SpawnObstacles()
    {
        for (int i = 0; i < obstacleCount; i++)
        {
            TrySpawnObstacle();
        }
    }

    private void TrySpawnObstacle()
    {
        const int maxAttempts = 50;

        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 position = new Vector3(
                Random.Range(minPosition, maxPosition),
                1f,
                Random.Range(minPosition, maxPosition)
            );

            float distanceFromPlayer =
                Vector3.Distance(position, player.position);

            if (distanceFromPlayer < minDistanceFromPlayer)
                continue;

            bool hasObstacle = Physics.CheckSphere(
                position,
                checkRadius,
                obstacleLayer
            );

            if (hasObstacle)
                continue;

            GameObject prefab =
                obstaclePrefabs[
                    Random.Range(0, obstaclePrefabs.Length)
                ];

            Instantiate(
                prefab,
                position,
                Quaternion.identity,
                obstacleContainer
            );

            return;
        }
    }
}