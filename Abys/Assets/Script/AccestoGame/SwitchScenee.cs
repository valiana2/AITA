using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenee : MonoBehaviour
{
     public int SceneBuildIndex;

     private void OnTriggerEnter2D(Collider2D other)
     {
         print("Trigger Entered");

        if(other.tag == "Player")
         {
             print("switching scene" + SceneBuildIndex);
             SceneManager.LoadScene(SceneBuildIndex, LoadSceneMode.Single);
         }

     }
}
