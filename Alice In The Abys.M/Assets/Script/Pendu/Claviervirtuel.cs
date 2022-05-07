using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class Claviervirtuel : MonoBehaviour
{
    private Word word = new Word();
    private string curWord;
    public Text txt;
    private string reponse;
    private bool win = false;
    public Sprite[] sp;
    public AudioClip SfxCorrect, SfxFailes;
    private AudioSource audiosource;
    public GameObject Pendu;
    private int i = 0;
    public GameObject PanelEnd;


    IEnumerator WaitOneFrame(float t) 
    {
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene("Indice3");
    }

    private void Awake() 
    {
        curWord = word.GetWord();
        audiosource = GetComponent<AudioSource>();
    }

    public void KeyboardPress(string letter)
    {
        Validation(letter);
    }

    private void Validation(string letter)
    {
        reponse = "";
        win = false;

        for (int i = 0; i < word.curWord.Length; i++)
        {
            if(txt.text.Substring(i,1) == "_")
            {
                if(word.curWord.Substring(i,1) == letter)
                {
                    reponse += letter;
                    win = true;
                }
                else 
                {
                    reponse += "_";
                }
            }
            else
            {
                reponse += txt.text.Substring(i,1);
            }
        }

        txt.text = reponse;
        Verification();
    }

    void Verification()
    {
        if (win)
        {
            audiosource.PlayOneShot(SfxCorrect);

            if(txt.text == curWord)
            {
                PanelEnd.SetActive(true);
                PanelEnd.GetComponentInChildren<Text>().text = "Bravo ! le mot était " + curWord;
                StartCoroutine(WaitOneFrame(2f));
            }
        }

        else
        {
            Pendu.GetComponent<Image>().sprite = sp[i];
            i++;
            audiosource.PlayOneShot(SfxFailes);

            if(i == 6)
            {
               PanelEnd.SetActive(true);
                PanelEnd.GetComponentInChildren<Text>().text = "Dommage ! le mot était " + curWord;
            }
        }
    }
}
