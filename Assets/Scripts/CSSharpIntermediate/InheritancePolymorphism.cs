using System.Collections.Generic;
using UnityEngine;

public class InheritancePolymorphism : MonoBehaviour
{
    void Start()
    {
        Enemy slime = new Slime();
        Enemy goblin = new Goblin();

        List<Enemy> enemies = new()
        {
            slime,
            goblin
        };

        foreach (Enemy enemy in enemies)
        {
            enemy.Attack();
            enemy.Attack2();
        }
    }
}

// 只要 class 裡有 abstract method，這個 class 本身也必須是 abstract class
public abstract class Enemy
{
    public virtual void Attack()
    {
        Debug.Log("Enemy attack");
    }

    public abstract void Attack2();
}

public class Slime : Enemy
{
    public override void Attack()
    {
        Debug.Log("Slime attack");
    }
    
    public override void Attack2()
    {
        Debug.Log("Slime Attack2");
    }
}

public class Goblin : Enemy
{
    public override void Attack()
    {
        Debug.Log("Goblin attack");
    }
    
    public override void Attack2()
    {
        Debug.Log("Goblin Attack2");
    }
}