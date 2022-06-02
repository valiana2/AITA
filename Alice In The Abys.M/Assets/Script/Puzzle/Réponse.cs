using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Réponse : MonoBehaviour
{
    public Text txt;
    public InputField ifText;
    [SerializeField]
    string s = " ";
    bool endGame = false;
    public GameObject Panel;


    private void Start() 
    {
        InitNb();
    }

    void InitNb()
    {
        endGame = false;
        s = "Alice In The Abys";
        txt.text = "Aide: Chaques mots commence par une majuscule";
        IfGetFocus();
    }

    IEnumerator WaitOneFrame(float t) 
    {
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene("Indice4");
    }

    IEnumerator WaitOneFrame2(float t) 
    {
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene("Forest");
    }

    public void Validation()
    {
        string n = (ifText.text);
        ifText.text = null;

        if(n == s)
        {
            txt.text = "Bravo tu as trouvé !!!";
            endGame = true;
            Panel.SetActive(true);
            Panel.GetComponentInChildren<Text>().text = "Bravo ! Tu obtiens l'indice";
            StartCoroutine(WaitOneFrame(2f));
        }
        else 
        {
            Panel.SetActive(true);
            Panel.GetComponentInChildren<Text>().text = "Dommage tu as echoué, recommence !!";
            StartCoroutine(WaitOneFrame2(2f));
        }

        IfGetFocus();
    }

    // Update is called once per frame
    void IfGetFocus()
    {
        ifText.Select();
        ifText.ActivateInputField();
    }
}
