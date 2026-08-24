using System;
using System.Linq;
using UnityEngine;

public class Lambda : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Func<int> getNumber = () => 10;
        Debug.Log(getNumber());
        Func<int, int> doubleNumber = x => x * 2;
        Debug.Log(doubleNumber(1));
        Func<int, int, int> addNumber = (a, b) => a + b;
        Debug.Log(addNumber(1, 2));
        
        Action printHello = () => Debug.Log("Hello");
        printHello();
        Action<int> printNumber = x => Debug.Log(x);
        printNumber(1);
        Action<int, int> printAddNumber = (a, b) => Debug.Log(a + b);
        printAddNumber(1, 2);
        
        int[] array = new[] { 2, 4, 3, 1, 5 };
        array
            .Where(number => number >= 3)
            .Select(number => number * 2)
            .OrderBy(number => number)
            .ToList()
            .ForEach(number => Debug.Log($"number: {number}"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
