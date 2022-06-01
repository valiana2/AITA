using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Réponses : MonoBehaviour
{
    public AudioClip SfxCorrect, SfxFailes;
    private AudioSource audiosource;
    public GameObject Panel;
    private void Awake() 
    {
        audiosource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        if(GameObject.Find("Canvas").GetComponent<Quizz>().Réponses == transform.GetChild(0).GetComponent<TextMesh>().text)
        {
            Debug.Log("Gagné");
            audiosource.PlayOneShot(SfxCorrect);
            GameObject.Find("Canvas").GetComponent<Quizz>().Score += 1;
        }
        else
        {
            audiosource.PlayOneShot(SfxFailes);
            Debug.Log("Perdu");
        }
        GameObject.Find("Canvas").GetComponent<Quizz>().PoseUneQuestion();
    }

}
