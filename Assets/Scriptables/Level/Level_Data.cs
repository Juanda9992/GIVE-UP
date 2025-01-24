using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level_", menuName = "Scriptables/Level/Level Data")]
public class Level_Data : ScriptableObject
{
    public List<Object_Data> level_Objects = new List<Object_Data>();
}

[System.Serializable]
public class Object_Data
{   
    public ObjectType objectType;
    public Vector2 objectPosition;
}

public enum ObjectType
{
    Block,
    Spike
}
