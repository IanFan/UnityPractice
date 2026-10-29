using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerHealth playerHealth;

    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private EnemySpawner enemySpawner;

    [SerializeField]
    private GameTimer gameTimer;

    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private TMP_Text gameOverText;

    private void Start()
    {
        playerHealth.Died += HandlePlayerDied;

        gameOverPanel.SetActive(false);

        gameTimer.StartTimer();
    }

    private void OnDestroy()
    {
        playerHealth.Died -= HandlePlayerDied;
    }

    private void HandlePlayerDied()
    {
        float survivalTime =
            gameTimer.StopTimer();

        playerController.StopMovement();

        enemySpawner.StopSpawning();

        StopAllEnemies();

        bool newBest = false;

        if (SaveManager.Instance != null)
        {
            newBest =
                SaveManager.Instance.TrySaveBestTime(
                    survivalTime
                );
        }

        gameTimer.RefreshBestTime();

        gameOverPanel.SetActive(true);

        if (newBest)
        {
            gameOverText.text =
                $"Game Over\n\n" +
                $"New Best!\n" +
                $"{survivalTime:F2} seconds";
        }
        else
        {
            gameOverText.text =
                $"Game Over\n\n" +
                $"Survival Time\n" +
                $"{survivalTime:F2} seconds";
        }
    }

    private void StopAllEnemies()
    {
        EnemyController[] enemies =
            FindObjectsByType<EnemyController>(
                FindObjectsSortMode.None
            );

        foreach (EnemyController enemy in enemies)
        {
            enemy.Stop();
        }
    }
}