using UnityEngine;

public class Fireball : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created      
    void Start()
    {
        Destroy(gameObject, 2f); // if it doesn't hit with anything within 2 sec, destroy itself
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.GetComponent<PlayerHealth>() != null)
        {                       
            player.GetComponent<PlayerHealth>().TakeDamage(1f); // do damage to player
            animator.Play("Explode");
            Destroy(gameObject, 1.5f); // destroy the fireball after hitting player.
        }
    }
}
