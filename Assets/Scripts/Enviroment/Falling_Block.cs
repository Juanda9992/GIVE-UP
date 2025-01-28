using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_Block : MonoBehaviour
{
    [SerializeField] private LayerMask groundAndPlayerLayer;
    private bool detectedPlayer = false;
    private Rigidbody2D rb;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();

        rb.isKinematic = true;    
    }
    private void Update() 
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.down,20,groundAndPlayerLayer);
        if(hit)
        {
            if(hit.transform.CompareTag("Player"))
            {
                rb.isKinematic = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        gameObject.SetActive(false);    
    }
}
