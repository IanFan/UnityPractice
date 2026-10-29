using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField, Min(1)] private int maxHits = 3;
    [SerializeField, Min(0f)] private float invulnerabilityDuration = 0.75f;

    public event Action Died;
    public event Action<int> HealthChanged;
    public bool IsDead { get; private set; }
    public int RemainingHits { get; private set; }
    private float nextHitAt;

    private void Awake()
    {
        RemainingHits = Mathf.Max(1, maxHits);
    }

    // A new collision counts once; simultaneous contacts share this cooldown.
    public bool TakeHit()
    {
        if (IsDead || Time.time < nextHitAt) return false;
        RemainingHits = Mathf.Max(0, RemainingHits - 1);
        nextHitAt = Time.time + invulnerabilityDuration;
        Debug.Log($"Player hit: {RemainingHits}/{maxHits} HP", this);
        HealthChanged?.Invoke(RemainingHits);
        if (RemainingHits == 0) Die();
        return true;
    }

    public void Die()
    {
        if (IsDead) return;
        RemainingHits = 0;
        IsDead = true;
        Debug.Log("Player Dead", this);
        Died?.Invoke();
    }
}
