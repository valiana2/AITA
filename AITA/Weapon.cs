using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//!!!!ATTENTION!!! ne pas oublier de passer la tag des IA ennemy en Figther
public class Weapon : Collidable
{
    //Damage struct surement inutile car pas de level up
    public int damagePoint = 1;
    public float pushForce = 2.0f;
    private Animator anim;
    
    //Swing
    private float cooldown = 0.5f;
    private float lastSwing;
    protected override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
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
        if (coll.tag == "Fighter")
        {
            if (coll.name != "Player")
            {
                Damage dmg = new Damage
                {
                    damageAmount = damagePoint,
                    origin = transform.position,
                    pushForce = pushForce
                };
                
                // create a new damage object and then send it to the fighter hit
                coll.SendMessage("ReceiveDamage", dmg);
            }
        }
    }

    private void Swing()
    {
        anim.SetTrigger("Swing");
    }
}
