using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject Panel;

    string[] Quiz = new string[3];

    // Start is called before the first frame update
    void Start()
    {
        TxtQuestion = GameObject.Find("TxtQuestion").GetComponent<Text>();
        TxtScore = GameObject.Find("Score").GetComponent<Text>();
        TxtBtnG = GameObject.Find("Réponse1").GetComponent<TextMesh>();
        TxtBtnD = GameObject.Find("Réponse2").GetComponent<TextMesh>();
        Quiz[0] = "Comment s'apelle le lapin à sauver ?,Gribouille,Magouille,Gribouille";
        Quiz[1] = "Comment s'apelle la personne qui vous as guider jusqu'au jeu ?,Angus,Brabus,Angus";
        Quiz[2] = "Combien de personnes as tu rencontrer jusqu'ici ?,3,4,4";

        PoseUneQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        TxtScore.text = "Score : " + Score;
    }

    IEnumerator WaitOneFrame(float t) 
    {
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene("Indice1");
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
            if(Score == 3)
            {
                Panel.SetActive(true);
                Panel.GetComponentInChildren<Text>().text = "Bravo ! Tu obtiens l'indice";
                StartCoroutine(WaitOneFrame(2f));
            }
            
            else
            {
                Panel.SetActive(true);
                Panel.GetComponentInChildren<Text>().text = "Dommage tu as échoué";
            }
        }
       
    }
}
