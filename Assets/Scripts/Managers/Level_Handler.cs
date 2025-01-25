using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level_Handler : MonoBehaviour
{
    public int currentLevel = 0;

    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Levels_Container levels_Container;


    [SerializeField] private GameObject block, spike;
    [SerializeField] private List<GameObject> objectsInLevel;
    private Dictionary<ObjectType,GameObject> objectDictionary;


    private void Awake() 
    {
        objectDictionary = new Dictionary<ObjectType, GameObject>();

        objectDictionary[ObjectType.Block] = block;
        objectDictionary[ObjectType.Spike] = spike;

    }
    public void IncreaseLevel()
    {
        currentLevel++;

        levelText.text = currentLevel >= 10 ? currentLevel.ToString() : "0"+currentLevel;

        LoadLevel();
    }

    [ContextMenu("Load Level")]
    public void LoadLevel()
    {
        ClearLevel();
        if(levels_Container.allLevels.Length > currentLevel)
        {
            Level_Data data = levels_Container.allLevels[currentLevel];
            for(int i = 0; i< data.level_Objects.Count;i++)
            {
                GameObject currentObject = Instantiate(objectDictionary[data.level_Objects[i].objectType],data.level_Objects[i].objectPosition,Quaternion.identity);
                objectsInLevel.Add(currentObject);
            }
        }
    }

    #if UNITY_EDITOR
    public void LoadLevel(Level_Data data)
    {
        objectDictionary = new Dictionary<ObjectType, GameObject>();

        objectDictionary[ObjectType.Block] = block;
        objectDictionary[ObjectType.Spike] = spike;

        ClearLevelInEditor();
        for(int i = 0; i< data.level_Objects.Count;i++)
        {
            GameObject currentObject = Instantiate(objectDictionary[data.level_Objects[i].objectType],data.level_Objects[i].objectPosition,Quaternion.identity);
            objectsInLevel.Add(currentObject);
        }
    }
    public void ClearLevelInEditor()
    {
        if(objectsInLevel.Count > 0)
        {
            for(int i = 0; i< objectsInLevel.Count;i++)
            {
                DestroyImmediate(objectsInLevel[i]);
            }
        }
        objectsInLevel.Clear();
    }

    #endif

    public void ClearLevel()
    {
        if(objectsInLevel.Count > 0)
        {
            for(int i = 0; i< objectsInLevel.Count;i++)
            {
                Destroy(objectsInLevel[i]);
            }
        }
        objectsInLevel.Clear();
    }
}
