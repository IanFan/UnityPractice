using System.Linq;
using UnityEngine;

public class LINQ : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int[] array = new[] { 2, 4, 3, 1, 5 };

        int[] selectArray = array.Select(x => x * 2).ToArray();
        Debug.Log($"selectArray: {string.Join(",", selectArray)}");

        bool any = array.Any(x => x == 2);
        Debug.Log($"any: {any}");

        bool all = array.All(x => x > 3);
        Debug.Log($"all: {all}");

        int min = array.Min(x => x);
        Debug.Log($"min: {min}");

        int max = array.Max(x => x);
        Debug.Log($"max: {max}");

        int first = array.First();
        Debug.Log($"first: {first}");

        int last = array.Last();
        Debug.Log($"last: {last}");

        int sum = array.Sum();
        Debug.Log($"sum: {sum}");

        int firstMatch = array.First(x => x >= 3);
        Debug.Log($"firstMatch: {firstMatch}");

        int firstOrDefault = array.FirstOrDefault(x => x == 10);
        Debug.Log($"firstOrDefault: {firstOrDefault}");

        int count = array.Count(x => x == 2);
        Debug.Log($"count: {count}");

        int[] whereArray = array.Where(x => x >= 4).ToArray();
        Debug.Log($"whereArray: {string.Join(",", whereArray)}");

        int[] orderArray = array.OrderBy(x => x).ToArray();
        Debug.Log($"orderArray: {string.Join(",", orderArray)}");

        int[] descArray = array.OrderByDescending(x => x).ToArray();
        Debug.Log($"descArray: {string.Join(",", descArray)}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
