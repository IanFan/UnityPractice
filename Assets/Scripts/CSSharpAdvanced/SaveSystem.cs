using System;
using System.IO;
using UnityEngine;


[Serializable]
public class PlayerSaveData
{
    public int level;
    public int gold;
}


public class SaveSystem : MonoBehaviour
{
    [SerializeField]
    private PlayerConfig config;

    private PlayerSaveData data;

    string SavePath =>
        Path.Combine(
            Application.persistentDataPath,
            "player.json"
        );


    void Start()
    {
        Debug.Log($"naxHP: {config.maxHp}");
        Debug.Log($"moveSpeed: {config.moveSpeed}");
        
        data = Load();
        Debug.Log($"Gold: {data.gold}");
        
        AddGold();
        Save();
        
        data = Load();
        Debug.Log($"Gold: {data.gold}");
    }


    public void AddGold()
    {
        data.gold += 10;
    }


    public void Save()
    {
        string json =
            JsonUtility.ToJson(data, true);

        File.WriteAllText(
            SavePath,
            json
        );
        
        Debug.Log($"JSON saved to: {SavePath}");
    }


    public PlayerSaveData Load()
    {
        if (!File.Exists(SavePath))
        {
            return new PlayerSaveData
            {
                level = 1,
                gold = 0
            };
        }

        string json =
            File.ReadAllText(SavePath);

        return JsonUtility
            .FromJson<PlayerSaveData>(json);
    }
}