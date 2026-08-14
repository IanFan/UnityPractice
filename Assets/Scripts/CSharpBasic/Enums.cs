using System;
using UnityEngine;

public class Enums : MonoBehaviour
{
    enum Level
    {
        low,
        mid,
        high,
    }
    
    private Level _level = Level.low;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switch(_level)
        {
            case Level.low: Debug.Log("low"); break;
            case Level.mid: Debug.Log("mid"); break;
            case Level.high: Debug.Log("high"); break;
            default: Debug.Log("default"); break;
        }
        
        var values = Enum.GetValues(typeof(Level));
        Debug.Log($"Level values length: {values.Length}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
