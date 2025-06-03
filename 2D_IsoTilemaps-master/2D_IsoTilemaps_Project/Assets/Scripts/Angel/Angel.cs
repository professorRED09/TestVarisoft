using UnityEngine;

public class Angel : MonoBehaviour
{
    Rigidbody2D rb; 

    // Finite State Machine
    Angel_BaseState currentState;
    public Angel_IdleState idleState = new Angel_IdleState();    
    public Angel_AttackState attackState = new Angel_AttackState();

    public GameObject player;
    public float distance;   
    public float attackRange;

    public Animator animator;
    public Transform shootPos;

    public Vector3 offSetVec;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        currentState = idleState;
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
        if (player == null)
        {
            SwitchState(idleState);
            return;
        }

        
        distance = Vector2.Distance(player.transform.position, transform.position);
        Vector2 facingDir = (Vector2)(player.transform.position + offSetVec - transform.position);
        shootPos.up = facingDir;
    }

    public void SwitchState(Angel_BaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
