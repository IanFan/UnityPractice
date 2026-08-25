using System.Collections.Generic;
using UnityEngine;

public class BulletPoolExample : MonoBehaviour
{
    private Queue<string> pool = new();

    private int createCount = 0;

    void Start()
    {
        Debug.Log($"Pool Count: {pool.Count}");
        
        // 第一次 Spawn：Pool 沒東西，所以建立新的
        string bullet1 = Spawn();
        string bullet2 = Spawn();

        // 用完後放回 Pool
        Despawn(bullet1);
        Despawn(bullet2);
        
        Debug.Log($"Pool Count: {pool.Count}");

        // 再次 Spawn：直接重複使用
        string bullet3 = Spawn();

        Debug.Log($"Spawn Bullet: {bullet3}");
        Debug.Log($"Pool Count: {pool.Count}");
        
        // 用完後放回 Pool
        Despawn(bullet3);
        
        Debug.Log($"Pool Count: {pool.Count}");
    }


    public string Spawn()
    {
        // Pool 有物件 → 重複使用
        if (pool.Count > 0)
        {
            string bullet = pool.Dequeue();

            Debug.Log($"Reuse: {bullet}");

            return bullet;
        }

        // Pool 沒物件 → 建立新的
        createCount++;

        string newBullet = $"Bullet {createCount}";

        Debug.Log($"Create: {newBullet}");

        return newBullet;
    }


    public void Despawn(string bullet)
    {
        Debug.Log($"Despawn: {bullet}");

        pool.Enqueue(bullet);
    }
}