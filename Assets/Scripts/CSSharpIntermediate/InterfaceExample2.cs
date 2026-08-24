using UnityEngine;

public class InterfaceExample2 : MonoBehaviour
{
    private IDamageable _interface;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _interface = GetComponent<IDamageable>();
        
        _interface.TakeDamage(10);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
