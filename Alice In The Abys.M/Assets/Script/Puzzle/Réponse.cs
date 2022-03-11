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

    private void Start() 
    {
        InitNb();
    }

    void InitNb()
    {
        endGame = false;
        s = "Alice In The Abys";
        txt.text = "Trouve la réponse";
        IfGetFocus();
    }

    public void Validation()
    {
        string n = (ifText.text);
        ifText.text = null;

        if(n == s)
        {
            txt.text = "Bravo tu as trouvé !!!";
            endGame = true;
            SceneManager.LoadScene(1);
        }
        else 
        {
            txt.text = "Réessaye, indice: chaque mot commence par une majuscule";
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
