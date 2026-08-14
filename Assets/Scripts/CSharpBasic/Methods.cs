using System;
using UnityEngine;

public class Methods : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MethodVoid(2);
        
        int result = MethodInt(2);
        Debug.Log($"MethodInt result: {result}");
        
        Action<int> action1 = MethodVoid;
        action1(2);
        
        Action action2 = () => MethodVoid();
        action2();
        
        Func<int, int> func = MethodInt;
        int funcResult = func(3);
        Debug.Log($"funcResult: {funcResult}");
        
        DoAction(action2);
        
        DoFunc(func);

        int number = 5;
        AddOne(ref number);
        Debug.Log($"AddOne number: {number}");

        bool isGetValue = TryGetValue(out int getValue);
        Debug.Log($"isGetValue: {isGetValue}, getValue: {getValue}");
        
        int doubleResult = Methods.Double(5);
        Debug.Log($"doubleResult: {doubleResult}");
    }

    void MethodVoid(int value = 1)
    {
        Debug.Log($"MethodVoid value: {value}");
    }

    int MethodInt(int value = 1)
    {
        int answer = value;
        return answer;
    }

    void DoAction(Action action)
    {
        Debug.Log($"DoAction action: {action}");
        action?.Invoke();
    }

    int DoFunc(Func<int, int> func)
    {
        int result = func.Invoke(1);
        Debug.Log($"DoFunc result: {result}");
        return result;
    }

    // ref Reference Passing（參考傳遞）
    void AddOne(ref int value)
    {
        value++;
    }

    // out Output Reference
    bool TryGetValue(out int value)
    {
        value = 100;
        return true;
    }
    
    public static int Double(int value)
    {
        return value * 2;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
