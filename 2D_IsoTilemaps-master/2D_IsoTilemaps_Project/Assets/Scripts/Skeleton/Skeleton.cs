using UnityEngine;

public class Skeleton : MonoBehaviour
{
    Rigidbody2D rb;
    public float movementSpeed;
    bool isFacingRight = true;

    // Finite State Machine
    Skeleton_BaseState currentState;
    public Skeleton_IdleState idleState = new Skeleton_IdleState();
    public Skeleton_WalkState walkState = new Skeleton_WalkState();
    public Skeleton_AttackState attackState = new Skeleton_AttackState();

    public GameObject player;
    public float distance;
    public float chaseRange;
    public float attackRange;

    public Animator animator;
    public Transform hitPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = idleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
        if (player == null)
        {
            SwitchState(idleState);
            return;
        }

        
        distance = Vector2.Distance(player.transform.position, transform.position);
        //Vector2 facingDir = (Vector2)(player.transform.position - transform.position);
        //hitPos.up = facingDir;

        //Check condition to flip enemy's sprite
        if (player.transform.position.x > transform.position.x && !isFacingRight)
        {
            Flip();  // Player is to the right and enemy is facing left, so flip
        }
        // Check if the player is to the left of the enemy
        else if (player.transform.position.x < transform.position.x && isFacingRight)
        {
            Flip();  // Player is to the left and enemy is facing right, so flip
        }
    }

    public void ChasePlayer()
    {
        Vector2 currentPos = rb.position;
        Vector2 facingDir = (Vector2)(player.transform.position - transform.position);  

        facingDir = Vector2.ClampMagnitude(facingDir, 1);
        Vector2 movement = facingDir * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.deltaTime;
        rb.MovePosition(newPos);     
    }

    void Flip()
    {        
        //if (status.isDead)
        //    return;
        isFacingRight = !isFacingRight;
        Vector3 direction = transform.localScale;
        direction.x *= -1;  // Flip the X-axis scale
        transform.localScale = direction;  // Apply the flipped scale
                
    }

    public void SwitchState(Skeleton_BaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
