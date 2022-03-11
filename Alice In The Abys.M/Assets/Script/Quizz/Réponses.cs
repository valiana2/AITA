using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Réponses : MonoBehaviour
{
    void OnMouseDown()
    {
        if(GameObject.Find("Canvas").GetComponent<Quizz>().Réponses == transform.GetChild(0).GetComponent<TextMesh>().text)
        {
            Debug.Log("Gagné");
            GameObject.Find("Canvas").GetComponent<Quizz>().Score += 1;
        }
        else
        {
            Debug.Log("Perdu");
        }
        GameObject.Find("Canvas").GetComponent<Quizz>().PoseUneQuestion();
    }

}
