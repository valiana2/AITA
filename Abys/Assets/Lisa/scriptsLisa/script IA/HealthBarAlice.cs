using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarAlice : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;// public

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }*/

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
