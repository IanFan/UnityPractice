using System;
using UnityEngine;

public class EventExample2 : MonoBehaviour
{ 
    private EventExample player;

    private void Awake()
    {
        player = GetComponent<EventExample>();
    }
    
    private void OnEnable()
    {
        player.onHealthChanged += updateHealth;
        player.onPlayerDead += showGameOver;
    }

    private void OnDisable()
    {
        player.onHealthChanged -= updateHealth;
        player.onPlayerDead -= showGameOver;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player.takeDamage(60);
        player.takeDamage(50);
    }

    void updateHealth(int hp)
    {
        Debug.Log($"updateHealth: {hp}");
    }

    void showGameOver()
    {
        Debug.Log("GameOver");
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
