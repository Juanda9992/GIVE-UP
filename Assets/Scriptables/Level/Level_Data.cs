using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level_", menuName = "Scriptables/Level/Level Data")]
public class Level_Data : ScriptableObject
{
    public List<Object_Data> level_Objects = new List<Object_Data>();

    public void AddObjectToList(Object_Editor_Data object_Editor_Data)
    {
        level_Objects.Add(new Object_Data(){objectType = object_Editor_Data.objectType,objectPosition = object_Editor_Data.transform.position,zRotation = object_Editor_Data.transform.rotation.eulerAngles.z});
    }
}

[System.Serializable]
public class Object_Data
{   
    public ObjectType objectType;
    public Vector2 objectPosition;
    public float zRotation;
}

public enum ObjectType
{
    Block,
    Spike
}
