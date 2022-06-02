using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NpcNav : MonoBehaviour
{
    
    public Vector3 position1;
    public Vector3 position2;
    public Animator animator;

    private bool isInRange;
    private bool goright;
    private int nbFrame;
    private int distance;
    public float speed2 = 100f;

    void Start()
    {
        
        transform.position = position1;
        goright = true;
        nbFrame = 0;
        if (position2.x - position1.x < 0)
        {
            distance =(int) (-(position2.x - position1.x) * 500);
        }
        else
        {
            distance = (int)((position2.x - position1.x) * 500);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            animator.SetBool("isTalking", true);
             animator.SetBool("goRight", false);
              animator.SetBool("goLeft", false);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            animator.SetBool("isTalking", false);
        }
    }


    void Update()
    {
        if (!isInRange)
        {
            
                if (goright)
                {
                    Debug.Log("ok");
                    animator.SetBool("goRight", true);
                    animator.SetBool("goLeft", false);
                    transform.position = transform.position + new Vector3(1f, 0, 0)*Time.deltaTime*speed2;
                    if (nbFrame >= distance)
                    {
                        goright = false;
                        nbFrame = 0;
                    }
                    else
                    {
                        nbFrame++;
                    }

                }
                else
                {
                    Debug.Log("ko");
                    animator.SetBool("goLeft", true);
                    animator.SetBool("goRight", false);
                    transform.position = transform.position - new Vector3(1f, 0, 0)*Time.deltaTime*speed2;
                    if (nbFrame >= distance)
                    {
                        goright = true;
                        nbFrame = 0;
                    }
                    else
                    {
                        nbFrame++;
                    }
                }
                nbFrame++;
            
        }
        
    }
}
