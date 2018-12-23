using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public int attackDamage = 20;

    public LayerMask whatIsPlayer;
    public float size = 0f;



    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.isTrigger && other.CompareTag("Player"))
        {
            PlayerHealth targetHealth = other.GetComponent<PlayerHealth>();
            if (!targetHealth.hurting)
            {
                targetHealth.TakeDamage(attackDamage);
                Debug.Log(targetHealth.currentHealth);
            }
        }
    }
}
