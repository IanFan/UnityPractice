using UnityEngine;

public class PatternMatchingExample : MonoBehaviour
{
    void Start()
    {
        object target = new MyEnemy();
        
        // 1. is：判斷型別 + 直接轉型
        if (target is MyEnemy enemy)
        {
            enemy.TakeDamage(10);
        }

        // 2. switch：依不同型別做不同事情
        switch (target)
        {
            case MyEnemy e:
                e.TakeDamage(20);
                break;

            case MyNPC npc:
                npc.Talk();
                break;
        }

        // 3. Property Pattern：判斷物件內容
        MyPlayer player = new MyPlayer { hp = 0 };

        if (player is { hp: <= 0 })
        {
            Debug.Log("Player Dead");
        }

        // 4. switch expression：條件直接產生結果
        player.hp = 20;

        string state = player.hp switch
        {
            <= 0 => "Dead",
            < 30 => "Danger",
            _ => "Healthy"
        };

        Debug.Log(state);
    }
}

public class MyPlayer
{
    public int hp;
}

public class MyEnemy
{
    public void TakeDamage(int damage)
    {
        Debug.Log($"Enemy Damage: {damage}");
    }
}

public class MyNPC
{
    public void Talk()
    {
        Debug.Log("NPC Talk");
    }
}