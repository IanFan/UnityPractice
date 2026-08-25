using UnityEngine;

public class ExtensionExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int num = 1.GetDouble();
        Debug.Log(num);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

// Extension Method 必須放在 static class 裡面
public static class IntExtensions
{
    // static + ReturnType + Method + (this ExistingType value + other parameters)
    public static int GetDouble(this int value)
    {
        return value * 2;
    }
}

