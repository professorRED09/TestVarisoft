using UnityEngine;

public class Spellball : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created      
    void Start()
    {        
        Destroy(gameObject,1f); // if it doesn't hit with anything within time, destroy itself
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.GetComponent<EnemyHealth>() != null)
        {            
            enemy.GetComponent<EnemyHealth>().TakeDamage(2f); // do damage to enemy
            Destroy(gameObject); // destroy the spellball after hitting enemy.
        }        
    }
}
