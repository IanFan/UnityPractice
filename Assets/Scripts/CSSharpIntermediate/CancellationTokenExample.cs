using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class CancellationTokenExample : MonoBehaviour
{
    private CancellationTokenSource _cts;

    async void Start()
    {
        _cts = new CancellationTokenSource();

        Task task = CountAsync(_cts.Token);

        await Task.Delay(5000);

        Debug.Log("Cancel!");

        _cts.Cancel();

        try
        {
            await task;
        }
        catch (OperationCanceledException)
        {
            Debug.Log("CountAsync cancelled");
        }

        _cts.Dispose();
    }

    async Task CountAsync(CancellationToken token)
    {
        for (int i = 0; i < 100; i++)
        {
            token.ThrowIfCancellationRequested();

            Debug.Log($"Count: {i}, time: {Time.realtimeSinceStartup}");

            await Task.Delay(200, token);
        }
    }
}
