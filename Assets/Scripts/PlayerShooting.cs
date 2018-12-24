using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int playerNumber = 1;
    public float shootCooldown = 0.5f;
    public float shootTriggerTimer = 0.1f;
    public Transform firePoint;
    public GameObject fireballPrefab;

    private float shootTimer;
    private string playerShootName;
    private Animator animator;
    private bool shooting = false;

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
        if (Input.GetButtonDown(playerShootName) && !shooting)
        {
            shooting = true;
            shootTimer = shootCooldown;
            animator.SetTrigger("shoot");
        }

        if (shooting)
        {
            if (shootTimer > 0)
            {
                shootTimer -= Time.deltaTime;

                if (shootTimer < shootTriggerTimer)
                {
                    Shoot();
                    shooting = false;
                }
            }
        }

        animator.SetBool("shooting", shooting);

    }

    void Shoot()
    {
        Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
    }

}
