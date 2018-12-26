using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Transform spawnPoint;
    [HideInInspector] public int playerNumber;
    [HideInInspector] public GameObject instance;

    private PlayerMovement movement;
    private PlayerAttack attacking;

    public void Setup()
    {
        movement = instance.GetComponent<PlayerMovement>();
        attacking = instance.GetComponent<PlayerAttack>();
        movement.playerNumber = playerNumber;
        attacking.playerNumber = playerNumber;
    }

    public void DisableControl()
    {
        movement.enabled = false;
        attacking.enabled = false;
    }

    public void EnableControl()
    {
        movement.enabled = true;
        attacking.enabled = true;
    }

    public void Reset()
    {
        instance.transform.position = spawnPoint.position;
        instance.transform.rotation = spawnPoint.rotation;
        
        instance.SetActive(false);
        instance.SetActive(true);
    }
}
