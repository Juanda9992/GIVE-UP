using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Respawn_Manager : MonoBehaviour
{   
    [SerializeField] private UnityEvent OnGameRestarted;
    [SerializeField] private InputActionReference restartAction;
    // Start is called before the first frame update
    void Start()
    {
        restartAction.action.performed += ResetGameByAction;    
    }

    private void ResetGameByAction(InputAction.CallbackContext context)
    {
        ResetGame();
    }
    
    private void ResetGame()
    {
        OnGameRestarted?.Invoke();
        Debug.Log("Reset Game");
    }

    public void ResetByDeath()
    {
        Debug.Log("Player Dead");
        ResetGame();
    }

}
