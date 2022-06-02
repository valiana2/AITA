using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class de combat du player qui herite de enemy et des fonctions de bases de combat
public class PlayerFight : MonoBehaviour
{
    //attributs du player
    public float cooldown; // 0.5f
    private float currentTime;
    public float attackDistance;
    private List<GameObject> graveyard;
    public List<GameObject> Graveyard => graveyard;
    
    /*// attributs HealthBar
    public int maxHealth = 100;
    public static int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    // fonction qui enlève la vie de la barre
    public static void GetDamage(int damage) // fais bouger la barre de vie
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }*/
    
    //attaque du player qui tue en 1 coup;
    private void Kill()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Ennemy");
        foreach (GameObject enemy in enemies)
        {
            if (Vector2.Distance(gameObject.transform.position, enemy.transform.position) < attackDistance)
            {
                enemy.SetActive(false);  //pas Destroy juste désactive car pour le GameOver il faudrait les recréer
                Graveyard.Add(enemy); //pour reset juste SetActive(true)
                return;
            }
        }
    }
    
    private void Update()
    {
        if (currentTime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))  // appuie sur espace pour attaquer 
            {
                Kill();
                currentTime = cooldown;
            }
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }
}