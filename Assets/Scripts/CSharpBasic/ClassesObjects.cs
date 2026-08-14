using UnityEngine;

public class ClassesObjects : MonoBehaviour
{
    void Start()
    {
        // 建立 Object
        Player player1 = new Player();

        player1.name = "Hero";
        player1.hp = 100;

        Debug.Log($"player1 name: {player1.name}, hp: {player1.hp}");


        // 使用 Constructor 建立 Object
        Player player2 = new Player("Enemy", 50);

        Debug.Log($"player2 name: {player2.name}, hp: {player2.hp}");


        // Reference Type 測試
        Player player3 = player2;

        player3.hp = 0;

        Debug.Log($"player2 hp: {player2.hp}");
    }
}


// Class（藍圖）
public class Player
{
    public string name;
    public int hp;


    // Constructor
    // 建立物件時自動執行
    public Player()
    {
        name = "Unknown";
        hp = 0;
    }


    // Constructor Overload
    public Player(string playerName, int playerHp)
    {
        name = playerName;
        hp = playerHp;
    }
}