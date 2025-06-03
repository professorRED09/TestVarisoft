using UnityEngine;

public class WaterBall : MonoBehaviour
{
    private Animator animator;
    Rigidbody2D rb;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created      
    void Start()
    {
        Destroy(gameObject, 1f); // if it doesn't hit with anything within time, destroy itself
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.GetComponent<EnemyHealth>() != null)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(1f); // do damage to player
            rb.linearVelocity = Vector2.zero;
            animator.Play("Impact");
            Destroy(gameObject, 0.3f); // destroy the fireball after hitting enemy.
        }
    }
}
