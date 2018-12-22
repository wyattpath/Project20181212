using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2D : MonoBehaviour
{
    public int playerNum = 1;
    public GameObject playerPrefab;
    public PlayerManager[] playerManagers;

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnAllPlayers();
    }

    private void SpawnAllPlayers()
    {
        for(int i = 0; i < playerNum; i++)
        {
            playerManagers[i].instance = Instantiate(playerPrefab, playerManagers[i].spawnPoint.position, playerManagers[i].spawnPoint.rotation) as GameObject;
            playerManagers[i].playerNumber = i + 1;
            playerManagers[i].Setup();
        }
    }
}
