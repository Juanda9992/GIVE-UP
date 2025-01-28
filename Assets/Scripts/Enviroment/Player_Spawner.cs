using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Spawner : MonoBehaviour
{
    [SerializeField] private Player_Controller _player_Controller;
    [SerializeField] private Transform spawnPoint;

    public Vector2 defaultPosition;
    // Start is called before the first frame update
    void Start()
    {
        RespawnPlayer();
    }

    public void RespawnPlayer()
    {
        _player_Controller.ResetSpeed();
        _player_Controller.transform.position = spawnPoint.position;
    }

}
