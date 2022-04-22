using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(3*x, 3*y, 0);

        //Swap Sprite direction (outdated)
        if (moveDelta.x > 0)
        {
            transform.localScale = new Vector3(3, 3, 1);
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-3, 3, 1);
        }
        //Checks collision
        
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y),
            Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actors", "Blocking"));
        
        //Move
        if (hit.collider == null)
        {
            transform.Translate(0,moveDelta.y * Time.deltaTime,0);
        }
        
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x,0),
            Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actors", "Blocking"));
        
        //Move
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x*Time.deltaTime, 0,0);
        }
    }
}
