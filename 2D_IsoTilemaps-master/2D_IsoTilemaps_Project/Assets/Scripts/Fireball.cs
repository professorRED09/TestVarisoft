using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created      
    void Start()
    {        
        Destroy(gameObject,2f); // if it doesn't hit with anything within 2 sec, destroy itself
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.GetComponent<EnemyHealth>() != null)
        {            
            enemy.GetComponent<EnemyHealth>().TakeDamage(2f); // do damage to enemy
            Destroy(gameObject); // destroy the fireball after hitting enemy.
        }        
    }
}
