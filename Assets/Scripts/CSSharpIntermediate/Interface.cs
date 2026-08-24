using UnityEngine;

public class Interface : MonoBehaviour, IDamageable
{
    
    public void TakeDamage(int damage)
    {
        Debug.Log(damage);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public interface IDamageable
{
    void TakeDamage(int damage);
}
