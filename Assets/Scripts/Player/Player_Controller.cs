using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    [Header("Movement Values")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpHeight;

    [Header("Ground Detection")]
    [SerializeField] private Transform checkAreaPosition;
    [SerializeField] private float checkAreaRadius;
    [SerializeField] private LayerMask groundDetectionLayerMask;

    [Header("Input Actions")]
    [SerializeField] private InputActionReference horizontal_Movement_Action;
    [SerializeField] private InputActionReference jump_Action;

    private bool canJump;
    private bool isJumping;
    private float movementAxis;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        movementAxis = horizontal_Movement_Action.action.ReadValue<float>();

        if(IsOnFloor())
        {
            if(jump_Action.action.WasPressedThisFrame())
            {
                isJumping = true;
            }     
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

    private bool IsOnFloor()
    {
        if(Physics2D.OverlapCircle(checkAreaPosition.position,checkAreaRadius,groundDetectionLayerMask))
        {
            return true;
        }
        return false;
    
    }

    public void ResetSpeed()
    {
        rb.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.transform.CompareTag("End"))
        {
            GameObject.FindObjectOfType<Level_Completion_Manager>().CompleteLevel();
        }    
        if(other.transform.CompareTag("Lethal"))
        {
            GameObject.FindObjectOfType<Respawn_Manager>().ResetByDeath();
        }
    }

    #if UNITY_EDITOR

    private void OnDrawGizmosSelected() 
    {
        Gizmos.DrawSphere(checkAreaPosition.position,checkAreaRadius);    
    }
    #endif
}
