using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float groundDrag;

    [Header("Movement")]
    public float moveSpeed;
    public Transform orientation;
    float horizontalInput;
    float verticalInput;
    
    public float jumpForce;
    public float airMultiplier;
    float jumpCooldown = 0.25f;
    float jumpTimer;

    float stamina = 100f;
    bool isRunning = false;

    [Header("Ground Drag")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool onGround;


    Vector3 moveDirection;
    public Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        } else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }

        MyInput();
        ControlSpeed();
        Drag();
        Run();
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(KeyCode.Space) && onGround && jumpTimer >= jumpCooldown)
        {
            onGround = false;
            jumpTimer = 0f;
            Jump();
        }

        jumpTimer += Time.deltaTime;
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (onGround) {
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        } else
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }

    }

    private void Drag()
    {
        onGround = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.1f, whatIsGround);
        if (onGround)
        {
            rb.linearDamping = groundDrag;
        } else
        {
            rb.linearDamping = 0f;
            onGround = false;
        }
    }

    private void ControlSpeed()
    {
        Vector3 horizontalVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if(horizontalVel.magnitude > moveSpeed && !isRunning)
        {
            Vector3 newVel = horizontalVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(newVel.x, rb.linearVelocity.y, newVel.z);
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector3 (rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void Run()
    {
        if (isRunning && verticalInput > 0)
        {
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
            rb.linearVelocity = new Vector3(moveDirection.x * (moveSpeed + 3), rb.linearVelocity.y, moveDirection.z * (moveSpeed + 3));
            Debug.Log("Running");
        } 
    }


}
