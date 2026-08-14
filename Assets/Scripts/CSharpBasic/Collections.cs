using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Collections : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        dictionary.Add(0, 0);
        dictionary.Remove(1);
        dictionary[1] = 2;
        Debug.Log(string.Join(", ", dictionary.Select(x => $"{x.Key}:{x.Value}")));
        Debug.Log(dictionary.ContainsKey(1));
        Debug.Log(dictionary.ContainsValue(1));
        Debug.Log(dictionary.TryGetValue(1, out int value));
        
        HashSet<int> set = new HashSet<int>();
        set.Add(1);
        set.Add(2);
        set.Add(1);
        set.Remove(2);
        Debug.Log(string.Join(",", set));
        Debug.Log(set.Contains(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
