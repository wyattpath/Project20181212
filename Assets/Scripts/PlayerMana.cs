using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{
    public float startingMana = 100f;
    public float currentMana = 0f;
    public float manaRegenerationPoints = 1f;
    public float manaRegenerationCooldown = .05f;
    public Slider manaSlider;

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
                manaSlider.value = currentMana;
                manaTimer = manaRegenerationCooldown;
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
        manaSlider.value = currentMana;
    }

    public bool canShoot(int amount)
    {
        return (currentMana - amount >= 0);
    }
}
