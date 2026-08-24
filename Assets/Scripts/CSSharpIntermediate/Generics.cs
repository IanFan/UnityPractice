using UnityEngine;

public class Generics : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Box<int> intBox = new Box<int>();
        intBox.value = 1;
        Debug.Log(intBox.value);
        
        Box<string> stringBox = new Box<string>();
        stringBox.value = "Hello";
        Debug.Log(stringBox.value);

        int intResult = intBox.GetValue(1);
        Debug.Log(intResult);
        
        string stringResult = stringBox.GetValue("Hello");
        Debug.Log(stringResult);
        
        Generics compoent = GetMyComponent<Generics>();
        Debug.Log(compoent);
    }

    public T GetMyComponent<T>() where T : Component // 泛型限制
    {
        return GetComponent<T>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

// 泛型 Class
public class Box<T>
{
    public T value;
    
    // 泛型 Method
    public T GetValue(T value)
    {
        return value;
    }
}
