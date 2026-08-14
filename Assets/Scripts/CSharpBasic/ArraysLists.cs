using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class ArraysLists : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int[] array1 = new int[2];
        array1[0] = 1;
        array1[1] = 2;
        array1[0] = 3;
        Debug.Log(string.Join(",", array1));
        Debug.Log($"array1 Length:{array1.Length}");
        
        int[] array2 = new [] {1,2};
        array2[0] = 3;
        array2[^1] = 4;
        Debug.Log(string.Join(",", array2));
        
        List<int> list1 = new List<int>();
        list1.Add(1);
        list1.Add(2);
        list1.RemoveAt(0);
        list1.Insert(0, 3);
        Debug.Log(string.Join(",", list1));
        Debug.Log($"list1 Count:{list1.Count}");
        
        List<int> list2 = new List<int>() {1,2};
        list2.Reverse();
        Debug.Log(string.Join(",", list2));
        
        List<int> list3 = new List<int>() {1,2};
        list3.Clear();
        Debug.Log(string.Join(",", list3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
