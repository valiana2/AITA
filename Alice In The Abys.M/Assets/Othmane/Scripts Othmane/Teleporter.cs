using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : Collidable
{
    public string[] sceneNames;
    
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            base.OnCollide(coll);
            string SceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            SceneManager.LoadScene(SceneName);
        }
    }
}
