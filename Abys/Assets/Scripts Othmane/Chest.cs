using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite NewSprite;
    public int CoinCount = 10;
    
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = NewSprite;
            Debug.Log("Grant" + CoinCount + "coins !");
        }
    }
}
