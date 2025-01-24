using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level_Handler : MonoBehaviour
{
    public int currentLevel = 0;

    [SerializeField] private TextMeshProUGUI levelText;

    public void IncreaseLevel()
    {
        currentLevel++;

        levelText.text = currentLevel >= 10 ? currentLevel.ToString() : "0"+currentLevel;
    }
}
