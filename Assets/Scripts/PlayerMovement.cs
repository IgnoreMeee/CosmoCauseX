using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public Button Resume;
    public Button Settings;
    public Button Exit;
    public float groundDrag;
    public bool paused = false;

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
    public bool canMove = true;


    Vector3 moveDirection;
    public Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        paused = false;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;
        if (Input.GetKeyDown(KeyCode.C)) Pause();

        if (paused)
        {
            return;
        }

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
        if (!canMove) return;

        if (paused) return;
        

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
        onGround = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
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
        } 
    }

    private void Pause()
    {
        if (paused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;

            Resume.gameObject.SetActive(false);
            Settings.gameObject.SetActive(false);
            Exit.gameObject.SetActive(false);

            paused = false;
            Time.timeScale = 1f;

        } else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Resume.gameObject.SetActive(true);
            Settings.gameObject.SetActive(true);
            Exit.gameObject.SetActive(true);

            paused = true;
            Time.timeScale = 0f;
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    void PauseMenu()
    {
        
    }


}