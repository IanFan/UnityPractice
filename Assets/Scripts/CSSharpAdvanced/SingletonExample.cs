using UnityEngine;

public class SingletonExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.gold += 10;
        Debug.Log($"Gold: {GameManager.Instance.gold}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
