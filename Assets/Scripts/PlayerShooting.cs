using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int playerNumber = 1;
    public float shootCooldown = 1.0f;
    public float shootTriggerTimer = 0.6f;
    public Transform firePoint;
    public GameObject fireballPrefab;

    private float shootTimer = -1.0f;
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
        if (Input.GetButtonDown(playerShootName) && !shooting && shootTimer <= 0)
        {
            shooting = true;
            shootTimer = shootCooldown;
            animator.SetTrigger("shoot");
        }

        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;

            if (shooting)
            {
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
