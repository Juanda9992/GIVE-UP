using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level_Completion_Manager : MonoBehaviour
{
    public UnityEvent OnLevelCompleted;
    public void CompleteLevel()
    {
        OnLevelCompleted?.Invoke();
        Debug.Log("Level Completed");
    }
}
