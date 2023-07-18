using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector2 moveDirection = Vector2.zero;
    public InputAction playerControls;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpForce = 150f;
    bool isClimbing = false;
    bool isGrounded = true;

    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.AddForce(transform.up * jumpForce);
            }
        }
    }


    void FixedUpdate()
    {
        if (!isClimbing)
        {
            rb.velocity = new Vector2(moveDirection.x * movementSpeed, rb.velocity.y );
        }
        
    }

    void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
