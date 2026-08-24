using System.Threading.Tasks;
using UnityEngine;

public class AsyncAwait : MonoBehaviour
{
    async void Start()
    {
        TestAsync();
    }

    async Task TestAsync()
    {
        await DoSomething();

        int result2 = await DoSomething2();
        Debug.Log($"result2: {result2}");

        int result3 = await DoSomething3(1);
        Debug.Log($"result3: {result3}");


        // 同時執行兩個 Task
        Task taskA = DoSomething();
        Task taskB = DoSomething();
        await Task.WhenAll(taskA, taskB);


        // 同時執行兩個有結果的 Task
        Task<int> taskC = DoSomething2();
        Task<int> taskD = DoSomething2();
        int[] results = await Task.WhenAll(taskC, taskD);
        int intC = await taskC;
        int intD = await taskD;

        Debug.Log($"taskC result: {taskC.Result}, results[0]: {results[0]}, intC: {intC}");
        Debug.Log($"taskD result: {taskD.Result}, results[0]: {results[1]}, intD: {intD}");
    }

    async Task DoSomething()
    {
        Debug.Log("DoSomething");

        await Task.Delay(1000);

        Debug.Log("Done");
    }

    async Task<int> DoSomething2()
    {
        Debug.Log("DoSomething2");

        await Task.Delay(1000);

        Debug.Log("Done");

        return 1;
    }

    async Task<int> DoSomething3(int i)
    {
        Debug.Log("DoSomething3");

        await Task.Delay(1000);

        Debug.Log("Done");

        return i;
    }
}