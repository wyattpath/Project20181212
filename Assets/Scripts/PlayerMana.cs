using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    public float startingMana = 100f;
    public float currentMana = 0f;
    public float manaRegenerationPoints = 20f;
    public float manaRegenerationCooldown = 1f;

    private float manaTimer;

    void OnEnable()
    {
        currentMana = startingMana;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMana < startingMana)
        {
            if (manaTimer > 0f)
            {
                manaTimer -= Time.deltaTime;
            }
            else
            {
                currentMana += manaRegenerationPoints;
            }
        }
        else
        {
            currentMana = startingMana;
        }
    }

    public void decreaseMana(int amount)
    {
        manaTimer = manaRegenerationCooldown;
        currentMana -= amount;
    }

    public bool canShoot(int amount)
    {
        return (currentMana - amount >= 0);
    }
}
