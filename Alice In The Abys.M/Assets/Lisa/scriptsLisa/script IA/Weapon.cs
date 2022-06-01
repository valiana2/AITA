using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//!!!!ATTENTION!!! ne pas oublier de passer la tag des IA ennemy en Figther
public class Weapon : Collidable
{
    //Damage struct surement inutile car pas de level up
    public int damagePoint = 1;
    public float pushForce = 2.0f;
    
    //Swing
    private float cooldown = 0.5f;
    private float lastSwing;
    protected override void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
            
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Figther")
        {
            // create a new damage object and then send it to the fighter hit
            Damage dmg = new Damage
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };
            
            coll.SendMessage("ReceiveDamage", dmg);
        }
    }

    private void Swing()
    {
        Debug.Log("Swing");
    }
}
