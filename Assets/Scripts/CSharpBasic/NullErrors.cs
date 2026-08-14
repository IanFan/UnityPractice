using System;
using UnityEngine;

public class NullErrors : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string name = null;
        Debug.Log($"name null: {name}");

        if (name == null)
        {
            Debug.Log($"name is null");
        }

        name?.ToUpper();

        if (name != null)
        {
            name.ToUpper();
        }
        
        name ??= "My Name";
        Debug.Log($"name ??=: {name}");
        
        string str = null ?? "My String";
        Debug.Log($"string ??: {str}");

        try
        {
            int number1 = int.Parse("123");
            Debug.Log($"Parse: {number1}");
            
            int number2 = int.Parse("abc");
            Debug.Log($"Parse: {number2}");
        }
        catch (Exception e)
        {
            // Console.WriteLine(e);
            Debug.Log($"error: {e}");
            throw;
        }
        finally
        {
            Debug.Log("finally");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
