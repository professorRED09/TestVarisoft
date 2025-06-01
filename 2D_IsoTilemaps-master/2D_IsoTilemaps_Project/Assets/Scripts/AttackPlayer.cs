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
        Collider2D[] hits = Physics2D.OverlapCircleAll(hitPos.position + new Vector3(xOffset, yOffset), attackRange, playerLayer);

        foreach (Collider2D player in hits)
        {            
            player.GetComponent<PlayerHealth>().TakeDamage();            
        }        
    }    

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(hitPos.position + new Vector3(xOffset, yOffset), attackRange);

    //}
}
