using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float shootingDamage = 10;
    public float speed = 20f;
    public float flyingTime = 1f;
    public Rigidbody2D rb2d;
    public GameObject impactEffect;
    [HideInInspector] public int playerNumber;
    [HideInInspector] public GameObject instance;

    private int targetNumber = 0;
    private float impactEffectDuration = .5f;

    void Awake()
    {
        rb2d.velocity = transform.right * speed;
        Destroy(gameObject, flyingTime);


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerShooting targetShooting = other.GetComponent<PlayerShooting>();
        if (targetShooting != null)
        {
            targetNumber = other.GetComponent<PlayerShooting>().playerNumber;
        }

        if (targetNumber != playerNumber || targetNumber == 0)
        {
            if (!other.isTrigger && (other.CompareTag("Player") || other.CompareTag("Platforms")))
            {
                PlayerHealth targetHealth = other.GetComponent<PlayerHealth>();
                if (targetHealth != null)
                {
                    targetHealth.TakeDamage(shootingDamage);
                }
                Destroy(gameObject);
            }
            targetNumber = 0;
        }
    }

    void OnDestroy()
    {
        impactEffect = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(impactEffect, impactEffectDuration);
    }
}
