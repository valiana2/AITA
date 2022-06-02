using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static int score;
    private int foodPoints = 10;
    public Text scoreText;

    public GameObject fishFood;
    private int foodTimer = 0;
    private int foodTimerGoal = 50;
    private int foodTimerRandom;


    // Start is called before the first frame update

    void Start()
    {
        score = 0;
        foodTimerRandom = Random.Range(0, 101);
    }
    

    void FixedUpdate()
    {
        if(foodTimer > foodTimerGoal + foodTimerRandom)
        {
            Instantiate(fishFood, new Vector2(Random.Range(-8f, 8f), 6f), Quaternion.identity);

            foodTimer = 0;
            foodTimerRandom = Random.Range(0, 101);
        }

        foodTimer++;
    }

    public void IncreaseScore()
    {
        score += foodPoints;
        scoreText.text = "Score: " + score;
    }
}
