using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public Cinemachine.CinemachineTargetGroup cameraGroup;
    public Transform[] spawnpoints;

    private PlayerManager[] players;
    Cinemachine.CinemachineTargetGroup.Target[] targets;



    private void Awake()
    {
        SpawnAllPlayers();
        SetupCameras();
    }

    private void SpawnAllPlayers()
    {
        players = new PlayerManager[spawnpoints.Length];
        for (int i = 0; i < players.Length; i++)
        {
            players[i] = gameObject.AddComponent<PlayerManager>();
            players[i].spawnPoint = spawnpoints[i];
            players[i].instance = Instantiate(playerPrefab, players[i].spawnPoint.position, players[i].spawnPoint.rotation) as GameObject;
            players[i].playerNumber = i + 1;
            players[i].Setup();

        }
    }

    private void SetupCameras()
    {
        targets = cameraGroup.m_Targets;

        for (int i = 0; i < players.Length; i++)
        {
            targets[i].target = players[i].instance.transform;
        }

        cameraGroup.m_Targets = targets;

    }

}
