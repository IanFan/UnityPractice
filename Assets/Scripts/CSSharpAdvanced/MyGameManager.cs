using UnityEngine;

public class MyGameManager : MonoBehaviour
{
    public static MyGameManager Instance { get; private set; }

    public int gold;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // DontDestroyOnLoad(gameObject);
    }

    public void AddGold(int value)
    {
        gold += value;
    }
}