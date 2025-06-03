using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    //[SerializeField] bool isAttacking;    
    [SerializeField] Transform hitPos;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] float xOffset;
    [SerializeField] float yOffset;

    // Attack player within the given collider
    public void Attack()
    {        
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRange, playerLayer);

        foreach (Collider2D player in hits)
        {            
            player.GetComponent<PlayerHealth>().TakeDamage(1.5f);            
        }        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.pink;
        Gizmos.DrawWireSphere(transform.position, attackRange);

    }
}
