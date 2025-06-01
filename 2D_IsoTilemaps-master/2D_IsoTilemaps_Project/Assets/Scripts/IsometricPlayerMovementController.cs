using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerMovementController : MonoBehaviour
{
    [SerializeField] FixedJoystick joystick; // ref for virtual joystick
    [SerializeField] GameObject spellball;
    [SerializeField] Transform shootPos;
    //public Vector2 lastFacingDir; // use to assign a direction to shoot fireball
    public float movementSpeed = 1f;
    public float bulletSpeed = 1f;
    IsometricCharacterRenderer isoRenderer;

    Rigidbody2D rbody;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 currentPos = rbody.position;

        float horizontalInput = /*Input.GetAxis("Horizontal")*/ joystick.Horizontal;
        float verticalInput = /*Input.GetAxis("Vertical")*/ joystick.Vertical;

        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);        
        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        isoRenderer.SetDirection(movement);
        rbody.MovePosition(newPos);

        if(inputVector.magnitude != 0)
        {
            shootPos.up = inputVector;
        }
        
    }

    public void Shoot()
    {        
        GameObject _spellball = Instantiate(spellball, shootPos.position, shootPos.rotation);
        Rigidbody2D fbRb = _spellball.GetComponent<Rigidbody2D>();
        fbRb.linearVelocity = bulletSpeed * shootPos.up;
    }
}
