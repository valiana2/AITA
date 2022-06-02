using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word : MonoBehaviour
{
    private List<string> lstWords = new List<string>();
    public string curWord;

    public Word()
    {
        lstWords.Add("CHERCHER");
        lstWords.Add("ENTERRER");
        lstWords.Add("FEERIQUE");
    }

    public string GetWord()
    {
        curWord = lstWords[Random.Range(0,lstWords.Count)];
        return curWord;
    }
}
