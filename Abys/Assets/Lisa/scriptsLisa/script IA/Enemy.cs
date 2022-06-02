using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script combat des IA enemy
public class Enemy : MonoBehaviour
{
    // attributs enemy
    public float attackDistance;
    public float cooldown; // 0.5f
    private float currentTime;
    public GameObject player;
    public HealthBarAlice healthBar;
    public int damage;
    
    private void Start()
    {
        currentTime = cooldown;
    }

    private void Update()
    {
        if (Vector2.Distance(gameObject.transform.position, player.transform.position) < attackDistance)
        {
            if (currentTime <= 0)
            {
                healthBar.TakeDamage(damage);
                currentTime = cooldown;
            }
            else
            {
                currentTime -= Time.deltaTime;
            }
        }
        else
        {
            currentTime = cooldown;
        }
        
    }

    /*
    // public fields
    public int hitpoint = 10;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 0.2f;
    
    //Immunity
    protected float immuneTime = 1.0f;
    protected float lastImmune;
    
    //Push 
    protected Vector3 pushDirection;
    
    //All fighters can Receive Damage /die
    protected virtual void ReceiveDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;
        }

        if (hitpoint <= 0)
        {
            hitpoint = 0;
            Death();
        }
    }

    protected virtual void Death()
    {
    }
    */

}
