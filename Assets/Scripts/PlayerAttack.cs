using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int playerNumber = 1;
    public Collider2D attackTrigger;
    public float attackCooldown = 0.67f;
    // Audio
    public AudioSource attackAudio;
    public AudioClip attackClip;

    private float attackTriggerTimer = 0.1f;
    private string playerAttackName;
    private bool attacking = false;
    private float attackTimer = 0;
    private Animator animator;
    private PlayerHealth playerHealth;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();
        attackTrigger.enabled = false;
    }

    private void Start()
    {
        playerAttackName = "Attack" + playerNumber;
    }

    private void Update()
    {

        if (Input.GetButtonDown(playerAttackName) && !attacking && !playerHealth.hurting)
        {
            attacking = true;
            animator.SetTrigger("attack");
            attackTimer = attackCooldown;

            attackAudio.clip = attackClip;
            attackAudio.Play();
        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
                if (attackTimer < attackTriggerTimer)
                    attackTrigger.enabled = true;

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
