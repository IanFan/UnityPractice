using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using UnityEngine;

public class TaskThreadExample : MonoBehaviour
{
    private int gold = 0;
    private readonly object _lock = new();
    
    async void Start()
    {
        // 1. Task：非同步等待
        await LoadData();
        
        // 2. Task.Run：背景執行緒計算
        int result = await Task.Run(() =>
        {
            return HeavyCalculation();
        });
        // 回到 Unity Main Thread
        Debug.Log(result);
        
        // 3. lock：避免 Race Condition
        await AddGoldTest();
        Debug.Log($"Gold: {gold}");
    }

    // Task 不代表 Thread
    async Task LoadData()
    {
        Debug.Log("Loading...");

        await Task.Delay(1000);

        Debug.Log("Done");
    }

    // CPU 運算放背景 Thread
    int HeavyCalculation()
    {
        int total = 0;

        for (int i = 0; i < 10000; i++)
        {
            total += i;
        }

        return total;
    }

    async Task AddGoldTest()
    {
        Task task1 = Task.Run(() =>
        {
            AddGold();
        });

        Task task2 = Task.Run(() =>
        {
            AddGold();
        });

        await Task.WhenAll(task1, task2);
    }

    void AddGold()
    {
        lock (_lock)
        {
            gold++;
        }
        
        //其實編譯器會幫你包成：
        /*
        Monitor.Enter(_lock);
        
        try
        {
            gold++;
        }
        finally
        {
            Monitor.Exit(_lock);
        }
        */
    }
}