using System;
using System.Threading.Tasks;
using UnityEngine;

public class ActionFuncDelegat : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    delegate void MyDelegate1();
    delegate void MyDelegate2(int number);
    delegate int MyDelegate3(int number);
    
    void Start()
    {
        MyDelegate1 delegatePrintHello = PrintyHello;
        delegatePrintHello.Invoke();

        MyDelegate2 delegatePrintNumber = PrintNumber;
        delegatePrintNumber.Invoke(10);

        MyDelegate3 delegateDoubleNumber = DoubleNumber;
        int result = delegateDoubleNumber.Invoke(1);
        Debug.Log($"delegateDoubleNumber: {result}");
        
        Action helloAction = () => { Debug.Log($"action1: Hello"); };
        helloAction.Invoke();
        Action<int> doubleAction = number => { Debug.Log($"action2: {number * 2}"); };
        doubleAction.Invoke(1);
        
        Func<int, int> doubleFunc = x => x * 2;
        Debug.Log($"doubleFunc: {doubleFunc}");
        
        LoadData(data =>
        {
            Debug.Log($"LoadData: {data}");
        });


        CheckAsync();
    }

    void PrintyHello()
    {
        Debug.Log("Hello");
    }

    void PrintNumber(int number)
    {
        Debug.Log(number);
    }

    int DoubleNumber(int number)
    {
        return number * 2;
    }

    void LoadData(Action<string> callback)
    {
        string data = "PLayer Data";
        callback.Invoke(data);
    }
    
    async Task<bool> CheckPlayerAsync(int id)
    {
        await Task.Delay(1000);

        return id > 0;
    }
    
    async void CheckAsync()
    {
        Func<int, Task<bool>> checkPlayerAsync = CheckPlayerAsync;
        bool result = await checkPlayerAsync(10);
        Debug.Log($"checkPlayerAsync: {result}");
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
