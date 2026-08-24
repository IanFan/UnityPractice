using UnityEngine;
using System;

public class EventExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private int hp = 100;
    
    public event Action<int> onHealthChanged;
    public event Action onPlayerDead;
    
    void Start()
    {
        
    }

    public void takeDamage(int damage)
    {
        hp -= damage;
        if (hp < 0)
        {
            hp = 0;
        }
        onHealthChanged?.Invoke(hp);
        if (hp == 0)
        {
            onPlayerDead?.Invoke();
        }
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
