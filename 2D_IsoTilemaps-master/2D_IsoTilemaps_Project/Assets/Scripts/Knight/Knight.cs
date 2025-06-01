using UnityEngine;

public class Knight : MonoBehaviour
{
    public float movementSpeed = 1f;
    KnightRender isoRenderer;

    public GameObject player;
    [SerializeField] float distance;

    Rigidbody2D rbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponent<KnightRender>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 currentPos = rbody.position;
        Vector2 facingDir = (Vector2)(player.transform.position - transform.position);
        distance = Vector2.Distance(player.transform.position, transform.position);
        
        facingDir = Vector2.ClampMagnitude(facingDir, 1);
        isoRenderer.SetDirection(facingDir,distance);
        //Vector2 movement = inputVector * movementSpeed;
        //Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;


        //if (facingDir.magnitude != 0)
        //{
        //    shootPos.up = inputVector;
        //}
    }
}
