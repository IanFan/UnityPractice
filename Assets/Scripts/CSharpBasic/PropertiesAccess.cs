using UnityEngine;

/*
 Access Modifier（存取修飾詞）

 public:
    所有人都可以存取
    用於公開 API、外部需要使用的功能

 private:
    只有自己 class 內可以存取
    最常用，用來保護資料

 protected:
    自己 class + 繼承的子 class 可以存取
    用於父類別提供資料給子類別

 internal:
    同一個 Assembly（通常同一個專案/DLL）可以存取
    大型專案模組內使用
 */

public class PropertiesAccess : MonoBehaviour
{
    // Encapsulation（封裝）
    // private 隱藏資料，避免外部直接修改
    private int health = 100;

    // Property（屬性）
    // 提供安全的讀取與修改入口
    public int Health
    {
        get
        {
            return health; // 取得值
        }
        set
        {
            health = value; // 設定值
        }
    }


    // protected:
    // 子類別可以使用，但外部不能存取
    protected int level;


    // internal:
    // 同一個 Assembly 可以使用
    internal int score;


    // Auto Property（自動屬性）
    // C# 幫忙建立 hidden backing field
    public int Level { get; set; }


    // Read Only Property（唯讀屬性）
    // 只能讀，不能外部修改
    public int MaxHealth { get; } = 100;


    // Unity 常用：
    // Inspector 可以看到
    // 但其他 Script 不能直接修改
    [SerializeField]
    private int speed = 5;


    // 常見遊戲寫法：
    // 外部可以讀 Score
    // 但只能這個 class 修改
    public int Score { get; private set; }


    // 修改 Score 的唯一入口
    public void AddScore(int value)
    {
        Score += value;
    }


    void Start()
    {
        Health = 80;

        Debug.Log($"Health: {Health}");
        Debug.Log($"MaxHealth: {MaxHealth}");

        AddScore(10);

        Debug.Log($"Score: {Score}");
    }


    void Update()
    {

    }
}