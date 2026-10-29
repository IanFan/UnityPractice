using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyController enemyPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private Transform enemyContainer;
    [SerializeField, Min(0.1f)] private float spawnInterval = 2f;
    [SerializeField, Min(0f)] private float minSpawnDistanceFromPlayer = 6f;
    [SerializeField] private BoxCollider westWall;
    [SerializeField] private BoxCollider eastWall;
    [SerializeField] private BoxCollider southWall;
    [SerializeField] private BoxCollider northWall;
    [SerializeField, Min(0.01f)] private float checkRadius = 0.75f;
    [SerializeField] private float spawnHeight = 1f;

    private Coroutine spawnCoroutine;
    private PlayerHealth playerHealth;

    private void Start()
    {
        if (enemyPrefab == null || player == null || westWall == null ||
            eastWall == null || southWall == null || northWall == null)
        {
            Debug.LogError("EnemySpawner requires a prefab, player and four wall colliders.", this);
            enabled = false;
            return;
        }
        playerHealth = player.GetComponent<PlayerHealth>();
        spawnCoroutine = StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        yield return new WaitForSeconds(1f);
        while (player != null && (playerHealth == null || !playerHealth.IsDead))
        {
            SpawnEnemy();
            yield return new WaitForSeconds(Mathf.Max(0.1f, spawnInterval));
        }
    }

    private void SpawnEnemy()
    {
        if (!TryGetSpawnPosition(out Vector3 position)) return;
        EnemyController enemy = Instantiate(enemyPrefab, position, Quaternion.identity, enemyContainer);
        enemy.Initialize(player);
        Physics.SyncTransforms();
    }

    // No valid location means skip this spawn, never fall back to an unsafe point.
    public bool TryGetSpawnPosition(out Vector3 position)
    {
        position = Vector3.zero;
        if (player == null || enemyPrefab == null || westWall == null ||
            eastWall == null || southWall == null || northWall == null) return false;

        BoxCollider shape = enemyPrefab.GetComponent<BoxCollider>();
        Vector3 size = Vector3.Scale(shape.size, enemyPrefab.transform.localScale);
        // Circumscribed horizontal radius keeps all cube corners inside the walls.
        float radius = Mathf.Max(checkRadius, new Vector2(size.x, size.z).magnitude * 0.5f + 0.05f);
        float minX = westWall.bounds.max.x + radius;
        float maxX = eastWall.bounds.min.x - radius;
        float minZ = southWall.bounds.max.z + radius;
        float maxZ = northWall.bounds.min.z - radius;
        if (minX > maxX || minZ > maxZ) return false;

        Collider playerCollider = player.GetComponent<Collider>();
        float playerRadius = playerCollider == null ? 0.5f :
            Mathf.Max(playerCollider.bounds.extents.x, playerCollider.bounds.extents.z);
        float safeDistance = Mathf.Max(minSpawnDistanceFromPlayer, radius + playerRadius + 0.1f);
        Physics.SyncTransforms();
        for (int i = 0; i < 50; i++)
        {
            Vector3 candidate = new Vector3(Random.Range(minX, maxX), spawnHeight,
                Random.Range(minZ, maxZ));
            Vector3 offset = candidate - player.position;
            offset.y = 0f;
            if (offset.sqrMagnitude < safeDistance * safeDistance) continue;
            // All solid layers: walls, obstacles, player, and existing enemies.
            if (Physics.CheckSphere(candidate, radius, ~0, QueryTriggerInteraction.Ignore)) continue;
            position = candidate;
            return true;
        }
        return false;
    }

    public void StopSpawning()
    {
        if (spawnCoroutine == null) return;
        StopCoroutine(spawnCoroutine);
        spawnCoroutine = null;
    }
}
