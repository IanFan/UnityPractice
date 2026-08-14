using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Loops : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        List<int> list = new List<int>() { 1, 2, 3 };

        foreach (int value in list)
        {
            Debug.Log($"foreach value: {value}");
        }

        for (int index = 0; index < list.Count; index++)
        {
            if (list[index] == 1)
            {
                continue;
            }

            if (list[index] == 2)
            {
                break;
            }

            Debug.Log($"for list[{index}]: {list[index]}");
        }

        int i = 0;
        while (i < list.Count)
        {
            Debug.Log($"while list[{i}]: {list[i]}");
            i++;
        }

        int j = 0;
        do
        {
            Debug.Log($"do while list[{j}]: {list[j]}");
            j++;
        }
        while (j < list.Count);

        Dictionary<int, int> dict = new Dictionary<int, int>();
        dict.Add(0, 0);
        dict.Add(1, 1);

        foreach (var (key, value) in dict)
        {
            Debug.Log($"dict key: {key}, value: {value}");
        }

        Debug.Log(
            $"dict: {string.Join(", ", dict.Select(x => $"{x.Key}:{x.Value}"))}"
        );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
