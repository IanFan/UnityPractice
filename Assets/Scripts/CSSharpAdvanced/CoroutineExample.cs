using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineExample : MonoBehaviour
{
    void Start()
    {
        // 1. IEnumerable + yield return
        foreach (int number in GetNumbers())
        {
            Debug.Log(number);
        }


        // 2. Coroutine
        StartCoroutine(Attack());
    }


    // IEnumerable：可以被 foreach 逐一取出
    IEnumerable<int> GetNumbers()
    {
        yield return 1;
        yield return 2;
        yield return 3;
    }


    // IEnumerator：Coroutine 使用
    IEnumerator Attack()
    {
        Debug.Log("Attack");

        yield return new WaitForSeconds(1);

        Debug.Log("Finish");
    }
}