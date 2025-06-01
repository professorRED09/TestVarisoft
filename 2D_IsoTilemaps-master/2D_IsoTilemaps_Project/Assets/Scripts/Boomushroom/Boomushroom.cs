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
    public float bombRange;

    public Animator animator;
    private SpriteRenderer render;

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
        Vector2 currentPos = rb.position;
        Vector2 facingDir = (Vector2)(player.transform.position - transform.position);

        facingDir = Vector2.ClampMagnitude(facingDir, 1);
        Vector2 movement = facingDir * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.deltaTime;
        rb.MovePosition(newPos);
        //StartCoroutine(EnemyFlash());
    }

    public IEnumerator EnemyFlash()
    {
        render.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        render.material.color = new Vector4(255, 255, 255, 1f); ;        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
