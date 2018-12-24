using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int playerNumber = 1;
    public Transform firePoint;
    public GameObject fireballPrefab;

    private string playerShootName;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        playerShootName = "Fire" + playerNumber;
    }

    void Update()
    {
        if(Input.GetButtonDown(playerShootName))
        {
            Shoot();    
        }
    }

    void Shoot()
    {
        Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
    }

}
