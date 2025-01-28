using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revert_Position : MonoBehaviour
{
    [SerializeField] private bool kinematicRb;
    private Vector2 initialPos;

    private void Awake() 
    {
        initialPos = transform.position;    
    }

    public void SetObjectInitialStatus()
    {
        GetComponent<Rigidbody2D>().isKinematic = kinematicRb;
        gameObject.SetActive(true);
        transform.position = initialPos;
    }
}
