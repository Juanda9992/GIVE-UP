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
        RevertObjectsStatus();
        Debug.Log("Reset Game");
    }

    public void ResetByDeath()
    {
        Debug.Log("Player Dead");
        ResetGame();
    }

    private void RevertObjectsStatus()
    {
        Revert_Position[] allDynamicObjects = GameObject.FindObjectsOfType<Revert_Position>(true);

        foreach(var obj in allDynamicObjects)
        {
            obj.SetObjectInitialStatus();
        }
    }

}
