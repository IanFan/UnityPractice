using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

    private const string BestTimeKey =
        "UnityBasic_BestTime";

    public float BestTime =>
        PlayerPrefs.GetFloat(BestTimeKey, 0f);

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public bool TrySaveBestTime(float time)
    {
        if (time <= BestTime)
            return false;

        PlayerPrefs.SetFloat(
            BestTimeKey,
            time
        );

        PlayerPrefs.Save();

        return true;
    }

    public void ResetBestTime()
    {
        PlayerPrefs.DeleteKey(BestTimeKey);
        PlayerPrefs.Save();
    }
}