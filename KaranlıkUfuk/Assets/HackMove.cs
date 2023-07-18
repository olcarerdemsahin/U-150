using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class HackMove : MonoBehaviour
{
    Rigidbody rb;
    Vector2 moveDirection = Vector2.zero;
    [SerializeField] float movementSpeed = 3f;
    public InputAction playerControls;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position +  new Vector3(moveDirection.x * movementSpeed * Time.deltaTime, moveDirection.y * movementSpeed * Time.deltaTime, 0);
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

    void OnHackMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "LabWall")
        {
            SceneManager.LoadScene(0);
        }
        else if(other.tag == "LabEnd")
        {
            SceneManager.LoadScene(0);
        }
    }
}
