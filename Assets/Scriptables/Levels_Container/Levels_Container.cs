using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Levels Container", menuName = "Scriptables/Level/Levels Container")]
public class Levels_Container : ScriptableObject
{
    public Level_Data[] allLevels;
}
