using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{

    //Swing
    private float cooldown = 0.5f;
    private float lastSwing;
    protected override void Start()
    {
       base.Start();
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

    private void Swing()
    {
        Debug.Log("Swing");
    }
}
