using UnityEngine;

public class SSkeleton : MonoBehaviour
{
    public float movementSpeed = 1f;
    public SSkeletonRender isoRenderer;

    // Finite State Machine
    SSkeleton_BaseState currentState;
    public SSkeleton_IdleState idleState = new SSkeleton_IdleState();
    public SSkeleton_ChaseState chaseState = new SSkeleton_ChaseState();
    public SSkeleton_AttackState attackState = new SSkeleton_AttackState();

    public GameObject player;
    public float distance;

    public Vector2 facingDir;
    public Animator animator;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();        
        isoRenderer = GetComponentInChildren<SSkeletonRender>();
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

        //Vector2 currentPos = rb.position;
        facingDir = (Vector2)(player.transform.position - transform.position);
        distance = Vector2.Distance(player.transform.position, transform.position);

        facingDir = Vector2.ClampMagnitude(facingDir, 1);
        //isoRenderer.SetDirection(facingDir, distance, player);
    }

    public void SwitchState(SSkeleton_BaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    public void ChasePlayer()
    {
        if (player == null) return;
        Vector2 currentPos = rb.position;
        Vector2 facingDir = (Vector2)(player.transform.position - transform.position);

        facingDir = Vector2.ClampMagnitude(facingDir, 1);
        Vector2 movement = facingDir * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.deltaTime;
        rb.MovePosition(newPos);
    }
}
