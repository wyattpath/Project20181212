using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public CameraControl2D cameraControl2D;
    public GameObject playerPrefab;
    public PlayerManager[] players;

    private void Awake()
    {
        cameraControl2D = GetComponent<CameraControl2D>();
        playerPrefab = GetComponent<GameObject>();
        
    }

    private void Start()
    {
        SpawnAllPlayers();
        SetCameraTargets();
    }

    private void SpawnAllPlayers()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].instance = Instantiate(playerPrefab, players[i].spawnPoint.position, players[i].spawnPoint.rotation) as GameObject;
            players[i].playerNumber = i + 1;
            players[i].Setup();
        }
    }

    private void SetCameraTargets()
    {
        // Create a collection of transforms the same size as the number of players
        Transform[] targets = new Transform[players.Length];

        // For each of thse transforms...
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i] = players[i].instance.transform;
        }

        // These are the targets the camera should follow
        cameraControl2D.targets = targets;
    }
}
