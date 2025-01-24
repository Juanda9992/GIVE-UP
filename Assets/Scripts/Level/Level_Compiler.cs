using System.IO;
using UnityEditor;
using UnityEngine;

public class Level_Compiler : Editor
{

    [MenuItem("Tools/Compile Level")]
    public static void CompileLevel()
    {
        Object_Editor_Data[] objectsToStore = GameObject.FindObjectsOfType<Object_Editor_Data>();

        Level_Data newLevel = ScriptableObject.CreateInstance<Level_Data>();

        for(int i = 0; i< objectsToStore.Length; i++)
        {
            newLevel.AddObjectToList(objectsToStore[i]);
        }

        
        string pathToCreateLevel = "Assets/Scriptables/Level/";

        string[] existingScriptables = Directory.GetFiles(pathToCreateLevel,"*.asset");

        string fileName = "Level_" + (existingScriptables.Length +1)+".asset";
        AssetDatabase.CreateAsset(newLevel,Path.Combine(pathToCreateLevel,fileName));
        Debug.Log($"Found {objectsToStore.Length} objects in scene" );
    }
}
