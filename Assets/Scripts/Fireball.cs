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

    // Start is called before the first frame update
    void Start()
    {
        rb2d.velocity = transform.right * speed;
        Destroy(gameObject, flyingTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.isTrigger && (other.CompareTag("Player") || other.CompareTag("Platforms")));
        {
            PlayerHealth targetHealth = other.GetComponent<PlayerHealth>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(shootingDamage);
            }

            impactEffect = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(impactEffect, .5f);
            Destroy(gameObject);
        }
    }
}
