using UnityEngine;

public class Knight : MonoBehaviour
{
    public float movementSpeed = 1f;
    public KnightRender isoRenderer;

    // Finite State Machine
    Knight_BaseState currentState;
    public Knight_IdleState idleState = new Knight_IdleState();
    public Knight_WalkState walkState = new Knight_WalkState();
    public Knight_AttackState attackState = new Knight_AttackState();

    public GameObject player;
    public float distance;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponent<KnightRender>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = idleState;
        currentState.EnterState(this);       
    }

    private void Update()
    {
        currentState.UpdateState(this);
        if (player == null)
        {
            SwitchState(idleState);
            return;
        }

        if (player == null) return;
        //Vector2 currentPos = rb.position;
        Vector2 facingDir = (Vector2)(player.transform.position - transform.position);
        distance = Vector2.Distance(player.transform.position, transform.position);

        facingDir = Vector2.ClampMagnitude(facingDir, 1);
        isoRenderer.SetDirection(facingDir, distance, player);
    }

    public void SwitchState(Knight_BaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

 
    void FixedUpdate()
    {

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
}
