using UnityEngine;
using System.Collections;

public class Boomushroom : MonoBehaviour
{
    Rigidbody2D rb;
    public float movementSpeed;
    bool isFacingRight = true;

    // Finite State Machine
    Boomushroom_BaseState currentState;
    public Boomushroom_IdleState idleState = new Boomushroom_IdleState();
    public Boomushroom_ChaseState chaseState = new Boomushroom_ChaseState();

    public GameObject player;
    public float distance;
    public float chaseRange;
    public float readyRange;
    public float bombRange;

    public Animator animator;
    private SpriteRenderer render;
    public LayerMask playerLayer;
    public GameObject explodeVFX;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        render = GetComponentInChildren<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = idleState;
        currentState.EnterState(this);

        distance = Vector2.Distance(player.transform.position, transform.position);
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

    public void SwitchState(Boomushroom_BaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public void Bomb()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, bombRange, playerLayer);
        foreach (Collider2D player in hits)
        {
            Instantiate(explodeVFX, transform.position, Quaternion.identity);
            player.GetComponent<PlayerHealth>().TakeDamage(2.5f);
        }
        Destroy(gameObject);
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

    public void ChasePlayer()
    {
        StartCoroutine(FlashFX());
        Vector2 currentPos = rb.position;
        Vector2 facingDir = (Vector2)(player.transform.position - transform.position);

        facingDir = Vector2.ClampMagnitude(facingDir, 1);
        Vector2 movement = facingDir * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.deltaTime;
        rb.MovePosition(newPos);        
    }

    public IEnumerator FlashFX()
    {
        render.material.color = Color.white;
        yield return new WaitForSeconds(1f);
        render.material.color = Color.red ;        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, bombRange);
    }
}
