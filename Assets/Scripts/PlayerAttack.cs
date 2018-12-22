using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int playerNumber = 1;
    public Collider2D attackTrigger;
    public float attackCooldown = 0.3f;

    private string playerAttackName;
    private bool attacking = false;
    private float attackTimer = 0;
    private Animator animator;
    private PlayerHealth playerHealth;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        attackTrigger.enabled = false;

        playerHealth = GetComponent<PlayerHealth>();

    }

    private void Start()
    {
        playerAttackName = "Attack" + playerNumber;
    }

    void Update()
    {

        if (Input.GetButtonDown(playerAttackName) && !attacking && !playerHealth.hurting)
        {
            attacking = true;
            animator.SetTrigger("attack");
            attackTimer = attackCooldown;
            attackTrigger.enabled = true;
        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }

        animator.SetBool("attacking", attacking);
    }
}
