using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quizz : MonoBehaviour
{
    private Text TxtQuestion;
    private Text TxtScore;
    private int Nr = 0;
    public string Réponses;
    public int Score = 0;
    public int Total = 2;
    private TextMesh TxtBtnG;
    private TextMesh TxtBtnD;
    private int NbQuestion = 0;

    string[] Quiz = new string[3];

    // Start is called before the first frame update
    void Start()
    {
        TxtQuestion = GameObject.Find("TxtQuestion").GetComponent<Text>();
        TxtScore = GameObject.Find("Score").GetComponent<Text>();
        TxtBtnG = GameObject.Find("Réponse1").GetComponent<TextMesh>();
        TxtBtnD = GameObject.Find("Réponse2").GetComponent<TextMesh>();
        Quiz[0] = "Comment s'apelle le lapin à sauver ?,Gribouille,Magouille,Magouille";
        Quiz[1] = "Comment s'apelle la personne qui vous as guider jusqu'au jeu ?,Dumbo,Mytho,Mytho";
        Quiz[2] = "Combien de personnes as tu rencontrer jusqu'ici ?,2,3,3";

        PoseUneQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        TxtScore.text = "Score : " + Score;
    }

    public void PoseUneQuestion()
    {
        if(NbQuestion <= Total)
        {
            NbQuestion += 1;
            string[] Col = Quiz[Nr].Split(',');
            TxtQuestion.text = Col[0];
            TxtBtnG.text = Col[1];
            TxtBtnD.text = Col[2];
            Réponses = Col[3];
            Nr += 1;
        }
        else
        {
            Debug.Log("Partie terminé");
        }
       
    }
}
