using System;
using UnityEngine;
using UnityEngine.Serialization;

//fonction qui fait poursuivre le joueur s'il est trop près de l'ennemi
public class IADeplacements : MonoBehaviour
{
    //attributs de Patrol()
    
    private bool _isArrivedLeft;
    private bool _isArrivedRight;
    public float left;
    public float right;
    bool _goRight = true;

    // attributs de Chase()
    public float speed;
    public Transform player;
    public Transform enemy;
    public float chaseDistance;
    /*
    // attributs combat system
    private bool collidingWithPlayer;
    
    // Hitbox (collider qui inflige les degats)
    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];
    //creer un object valeur = null et si infliction degats => condition si object == nul => aller chercher le player avec le tag (comme çà on le cherche qu'une seule fois)
    
    
    //fonctions combat system
    protected void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }
    */
    // fonctions deplacements
    
    // fonction Patrol
    public void Patrol()
    {
        float x = enemy.position.x;
        if (x < left || x > right)    // cas où l'IA est en dehors des bornes : rester sur place
                                      
        {
            enemy.position = enemy.localPosition;
        }
        else
        {
            _isArrivedLeft = Math.Abs(x - left) <= 0.2f;
            _isArrivedRight = Math.Abs(x - right) <= 0.2f;
            if (_goRight)
            {
                if (_isArrivedRight)
                {
                    _goRight = false;
                }
                else
                {
                    enemy.Translate(Vector2.right * (speed * Time.deltaTime));
                }
            }
            else
            {
                if (_isArrivedLeft)
                {
                    _goRight = true;
                }
                else
                {
                    enemy.Translate(Vector2.left * (speed * Time.deltaTime));
                }
            }
        
        }
        
    }
    
    /* A rajouter: faire une fonction qui chande de direction si npc rencontre collider
     private void OnCollisionEnter*/
    
    public void Chase(Transform player)
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void Update()
    {
        if (Vector2.Distance(enemy.position, player.position) < chaseDistance)
        {
            Chase(player);
            // condition enemy assez proche => prend des dégats
            /*if (collidingWithPlayer)
            {
                Debug.Log("player touched");
            }*/
        }
        else
        {
            Patrol();
        }
        // check for min attack distance
        /*collidingWithPlayer = false;
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i]==null)
            {
                continue;
            }

            if (hits[i].tag == "Ennemy")
            {
                collidingWithPlayer = true;
            }
            hits[i] = null;
        }*/
    }
    /*
    protected override void Death()
    {
        Destroy(gameObject);
        Debug.Log("enemy killed");
    }
    */
}