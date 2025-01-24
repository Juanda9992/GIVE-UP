using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input_Actions_Handler : MonoBehaviour
{
    [SerializeField] private InputActionAsset[] actionsToEnable;

    private void Awake() 
    {
        foreach(InputActionAsset action in actionsToEnable)
        {
            action.Enable();
        }    
    }
}
