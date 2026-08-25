using System;
using System.Reflection;
using UnityEngine;

public class AttributeReflectionExample : MonoBehaviour
{
    [SerializeField]
    [Header("Player")]
    [Tooltip("Player hp")]
    [Range(0,100)]
    private int hp = 100;

    [HideInInspector] 
    private int mp = 50;
    
    void Start()
    {
        Debug.Log($"hp: {hp}");
        Debug.Log($"mp: {mp}");
        
        PlayerData data = new PlayerData();

        // Reflection 取得 Class 資訊
        Type type = typeof(PlayerData);

        FieldInfo[] fields = type.GetFields();

        foreach (FieldInfo field in fields)
        {
            Debug.Log($"Field: {field.Name}");

            // 判斷是否有 SaveField Attribute
            if (Attribute.IsDefined(field, typeof(SaveFieldAttribute)))
            {
                Debug.Log($"{field.Name} needs save");
            }
        }
    }
}

// 自訂 Attribute
[AttributeUsage(AttributeTargets.Field)]
public class SaveFieldAttribute : Attribute
{
}

// 資料類別
public class PlayerData
{
    // SaveField是自己取的
    // [SaveField]會自動找後綴[SaveFieldAttribute]
    [SaveField]
    public int level = 10;

    [SaveField]
    public int gold = 100;

    public int temporaryValue = 999;
}