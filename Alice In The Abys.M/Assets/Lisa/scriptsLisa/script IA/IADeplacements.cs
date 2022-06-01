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

    // fonction Patrol
    public void Patrol()
    {
        float x = enemy.position.x;
        if (x < left || x > right)    // cas où l'IA est en dehors des bornes : rester sur place
                                      // a modifier en pathfinding plus tard
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
    
    /*public void Chase(player)
    {
        
    }*/

    void Update()
    {
        if (Vector2.Distance(enemy.position, player.position) < chaseDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            Patrol();
        }
    }
}