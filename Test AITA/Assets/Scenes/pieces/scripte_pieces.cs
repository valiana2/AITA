using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scripte_pieces : MonoBehaviour
{
    public int nbCoin =0;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "coin")
        {
            nbCoin++;
            Destroy(other.gameObject);
        }
    }
}
