using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level_Handler : MonoBehaviour
{
    public int currentLevel = 0;

    [SerializeField] private Vector2 defaultSpawnerPos;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Levels_Container levels_Container;


    [SerializeField] private GameObject block, spike,falling_Block,breakable_Block;
    [SerializeField] private List<GameObject> objectsInLevel;
    private Dictionary<ObjectType,GameObject> objectDictionary;


    private void Awake() 
    {
        InitializeObjectsDictionary();
    }

    private void InitializeObjectsDictionary()
    {
        objectDictionary = new Dictionary<ObjectType, GameObject>();

        objectDictionary[ObjectType.Block] = block;
        objectDictionary[ObjectType.Spike] = spike;
        objectDictionary[ObjectType.Falling_Block] = falling_Block;
        objectDictionary[ObjectType.Breakable_Block] = breakable_Block;
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
                GameObject currentObject = Instantiate(objectDictionary[data.level_Objects[i].objectType],data.level_Objects[i].objectPosition,Quaternion.Euler(0,0,data.level_Objects[i].zRotation));
                currentObject.transform.localScale = data.level_Objects[i].objectScale;
                objectsInLevel.Add(currentObject);

                GameObject.FindObjectOfType<Player_Spawner>().transform.position = data.spawnerPosition != Vector2.zero ? data.spawnerPosition : defaultSpawnerPos;
            }
        }
    }

    #if UNITY_EDITOR
    public void LoadLevel(Level_Data data)
    {
        InitializeObjectsDictionary();
        for(int i = 0; i< data.level_Objects.Count;i++)
        {
            GameObject currentObject = Instantiate(objectDictionary[data.level_Objects[i].objectType],data.level_Objects[i].objectPosition,Quaternion.Euler(0,0,data.level_Objects[i].zRotation));
            currentObject.transform.localScale = data.level_Objects[i].objectScale;
            GameObject.FindObjectOfType<Player_Spawner>().transform.position = data.spawnerPosition != Vector2.zero ? data.spawnerPosition : defaultSpawnerPos;
        }
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
