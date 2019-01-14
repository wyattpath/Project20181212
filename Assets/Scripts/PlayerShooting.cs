using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int playerNumber = 1;
    public float shootCooldown = 1f;
    private float shootTriggerTimer = 0.6f;
    public Transform firePoint;
    public GameObject fireballPrefab;
    public int manaCost = 20;

    private float shootTimer = -1.0f;
    private string playerShootName;
    private Animator animator;
    private bool shooting = false;
    private PlayerMana playerMana;

    // Mana

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        playerShootName = "Fire" + playerNumber;
        playerMana = GetComponent<PlayerMana>();

        // animation speed
        animator.speed /= shootCooldown;
        shootTriggerTimer *= shootCooldown;
    }

    void Update()
    {
        if (Input.GetButtonDown(playerShootName) && !shooting && shootTimer <= 0)
        {
            if (playerMana.canShoot(manaCost))
            {
                playerMana.decreaseMana(manaCost);
                shooting = true;
                shootTimer = shootCooldown;
                animator.SetTrigger("shoot");
            }
        }
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }
        if (shooting)
        {
            if (shootTimer < shootTriggerTimer)
            {
                Shoot();
                shooting = false;
            }
        }
        animator.SetBool("shooting", shooting);
    }
    void Shoot()
    {
        Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
    }

}
