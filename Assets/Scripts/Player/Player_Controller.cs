using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpHeight;

    [SerializeField] private InputActionReference horizontal_Movement_Action;
    [SerializeField] private InputActionReference jump_Action;

    private bool isJumping;
    private float movementAxis;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        movementAxis = horizontal_Movement_Action.action.ReadValue<float>();

        if(jump_Action.action.WasPressedThisFrame())
        {
            isJumping = true;
        }     
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(movementAxis * movementSpeed, rb.velocity.y);
        if(isJumping)
        {
            isJumping = false;
            rb.velocity = new Vector2(rb.velocity.x,jumpHeight);
        }
    }
}
