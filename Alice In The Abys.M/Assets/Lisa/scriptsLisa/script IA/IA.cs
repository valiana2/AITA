using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class IA : MonoBehaviour
{

    public float up;
    public float down;
    public float left;
    public float right; 
    public float chaseDistance;
    public Transform player;
    public Transform enemy;
    public float speed;

    bool _isArrived = true;
    Vector2 _newPose;

    void Patrol()
    {
/*
        if (isArrived)
        {
            newPose.x = down;
            newPose.y = left;
            ennemy.Translate(newPose * speed * Time.deltaTime);
        }*/
        
        if (_isArrived)
        {
            float x = Random.Range(-1.5f, 1.5f);
            float y = Random.Range(-1.5f, 1.5f);

            if (enemy.position.x + x > left)
            {
                if (enemy.position.x + x < right)
                {
                    _newPose.x = enemy.position.x + x;
                }
                else
                {
                    _newPose.x = right;
                }
            }
            else
            {
                _newPose.x = left;
            }

            if (enemy.position.y + y > down)
            {
                if (enemy.position.y + y < up)
                {
                    _newPose.y = enemy.position.y + y;
                }
                else
                {
                    _newPose.y = up;
                }
            }
            else
            {
                _newPose.y = down;
            }
        }
        else if( Vector2.Distance(enemy.position, _newPose) <= 0.2f)
        {
            _isArrived = true;
        }
        enemy.Translate(_newPose * speed * Time.deltaTime);
        
    }

    void Chase()
    {
        enemy.position = Vector2.MoveTowards(enemy.position, player.position, speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(enemy.position, player.position) < chaseDistance)
        {
            Chase();
        }
        else
        {
            Patrol();
        }
    }
}
