using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float startingHealth = 100f;
    public float currentHealth = 0f;
    public float hurtCooldown = 0.3f;
    [HideInInspector] public bool hurting;

    private Animator animator;
    private bool dead;
    private float hurtTimer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        currentHealth = startingHealth;
        dead = false;
        hurting = false;
    }

    public void TakeDamage(float amount)
    {
        if (!hurting)
        {
            hurting = true;
            hurtTimer = hurtCooldown;
            animator.SetTrigger("hurt");
            currentHealth -= amount;
        }

        if (currentHealth <= 0f && !dead)
        {
            OnDeath();
        }
    }


    private void OnDeath()
    {
        dead = true;
        animator.SetTrigger("die");
    }
    private void Update()
    {
        if (hurting)
        {
            if (hurtTimer > 0)
            {
                hurtTimer -= Time.deltaTime;
                Debug.Log(hurtTimer);
            }
            else
            {
                hurting = false;
            }
        }

        animator.SetBool("hurting", hurting);
    }
}
