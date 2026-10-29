using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timerText;

    [SerializeField]
    private TMP_Text bestTimeText;

    private float elapsedTime;

    private bool isRunning;

    public float ElapsedTime => elapsedTime;

    private void Start()
    {
        RefreshBestTime();
    }

    private void Update()
    {
        if (!isRunning)
            return;

        elapsedTime += Time.deltaTime;

        timerText.text =
            $"Time: {elapsedTime:F2}";
    }

    public void StartTimer()
    {
        elapsedTime = 0f;
        isRunning = true;

        timerText.text = "Time: 0.00";
    }

    public float StopTimer()
    {
        isRunning = false;

        return elapsedTime;
    }

    public void RefreshBestTime()
    {
        float bestTime =
            SaveManager.Instance != null
                ? SaveManager.Instance.BestTime
                : 0f;

        bestTimeText.text =
            $"Best: {bestTime:F2}";
    }
}