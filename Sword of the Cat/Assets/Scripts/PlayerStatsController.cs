using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsController : MonoBehaviour
{
    public float specialMax;
    public float special;
    public float healthMax;
    public float health;
    public Slider specialBar;

    void Update()
    {
        specialBar.maxValue = specialMax;
        specialBar.value = special;
    }

    public void AddSpecial(float amount)
    {
        special += amount;
        if (special > specialMax)
        {
            special = specialMax;
        }
    }

    public void AddHealth(float amount)
    {
        health += amount;
        if (health > healthMax)
        {
            health = healthMax;
        }
    }

    public bool UseSpecial(float amount)
    {
        if (special >= amount)
        {
            special -= amount;
            return true;
        } else
        {
            return false;
        }
    }
    public void Damage(float amount)
    {
        health -= amount;
    }
}
