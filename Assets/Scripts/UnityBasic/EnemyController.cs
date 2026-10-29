using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class EnemyController : MonoBehaviour
{
    [SerializeField, Min(0f)] private float moveSpeed = 3f;
    [SerializeField, Min(0f)] private float chaseAcceleration = 12f;
    [SerializeField, Min(0f)] private float knockbackSpeed = 6f;
    [SerializeField, Min(0f)] private float knockbackDuration = 0.3f;

    private Rigidbody rb;
    private Transform target;
    private PlayerHealth targetHealth;
    private bool canMove = true;
    private float resumeChaseAt;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Initialize(Transform player)
    {
        target = player;
        targetHealth = player != null ? player.GetComponent<PlayerHealth>() : null;
    }

    private void FixedUpdate()
    {
        if (!canMove || target == null || (targetHealth != null && targetHealth.IsDead))
            return;

        if (Time.time >= resumeChaseAt)
            ChasePlayer();
    }

    // Change this function to implement a different pursuit strategy.
    public Vector3 CalculateChaseDirection()
    {
        if (target == null) return Vector3.zero;
        Vector3 direction = target.position - rb.position;
        direction.y = 0f;
        return direction.normalized;
    }

    private void ChasePlayer()
    {
        Vector3 velocity = rb.linearVelocity;
        Vector3 horizontal = new Vector3(velocity.x, 0f, velocity.z);
        horizontal = Vector3.MoveTowards(horizontal, CalculateChaseDirection() * moveSpeed,
            chaseAcceleration * Time.fixedDeltaTime);
        rb.linearVelocity = new Vector3(horizontal.x, velocity.y, horizontal.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerHealth health = collision.gameObject.GetComponentInParent<PlayerHealth>();
        if (health == null || health.IsDead || !canMove) return;

        // Only this enemy receives knockback; never move the shared container.
        PushAwayFrom(health.transform.position);
        health.TakeHit();
    }

    public void PushAwayFrom(Vector3 sourcePosition)
    {
        if (!canMove) return;
        Vector3 direction = rb.position - sourcePosition;
        direction.y = 0f;
        if (direction.sqrMagnitude < 0.0001f) direction = Vector3.forward;
        Vector3 velocity = direction.normalized * knockbackSpeed;
        velocity.y = rb.linearVelocity.y;
        rb.linearVelocity = velocity;
        resumeChaseAt = Time.time + knockbackDuration;
    }

    public void Stop()
    {
        canMove = false;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
    }
}
