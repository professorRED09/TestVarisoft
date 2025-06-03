using UnityEngine;
using System.Collections;

public class Fox : MonoBehaviour
{
    Rigidbody2D rb;
    public float movementSpeed;
    public FoxRender isoRenderer;
    //bool isFacingRight = true;

    // Finite State Machine
    Fox_BaseState currentState;
    public Fox_IdleState idleState = new Fox_IdleState();
    public Fox_ChaseState chaseState = new Fox_ChaseState();

    public GameObject player;
    public float distance;
    public float bombRange;
    public Vector2 facingDir;

    public Animator animator;
    private SpriteRenderer render;
    public LayerMask playerLayer;
    public GameObject explodeVFX;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        render = GetComponentInChildren<SpriteRenderer>();
        isoRenderer = GetComponentInChildren<FoxRender>();
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
    
        facingDir = (Vector2)(player.transform.position - transform.position);
        distance = Vector2.Distance(player.transform.position, transform.position);

        facingDir = Vector2.ClampMagnitude(facingDir, 1);  
    }

    public void SwitchState(Fox_BaseState state)
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

    //void Flip()
    //{
    //    //if (status.isDead)
    //    //    return;
    //    isFacingRight = !isFacingRight;
    //    Vector3 direction = transform.localScale;
    //    direction.x *= -1;  // Flip the X-axis scale
    //    transform.localScale = direction;  // Apply the flipped scale

    //}

    public void ChasePlayer()
    {
        if (player == null) return;
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
}
