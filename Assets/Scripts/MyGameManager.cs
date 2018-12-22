using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public PlayerManager[] players;
    public Transform[] spawnPoint;


    private void Awake()
    {
        SpawnAllPlayers();
    }

    private void SpawnAllPlayers()
    {
        for(int i = 0; i < players.Length; i++)
        {
            players[i].instance = Instantiate(playerPrefab) as GameObject;
            players[i].playerNumber = i + 1;
            players[i].Setup();

        }
    }

}
