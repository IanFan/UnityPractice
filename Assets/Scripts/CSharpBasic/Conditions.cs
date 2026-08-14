using UnityEngine;

public class Conditions : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bool b = true;
        if (b)
        {
            Debug.Log("if-else true");
        }
        else
        {
            Debug.Log("if-else false");
        }

        int a = 0;
        switch(a)
        {
            case 0:
            {
                Debug.Log("switch case"); break;
            }
            default:
            {
                Debug.Log("switch default"); break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
