using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DialogueMana : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public bool startTalking = false;
    public Animator animator;

    private Queue<string> talking;
    // Start is called before the first frame update
    void Start()
    {
        talking = new Queue<string>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && startTalking)
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue (Dialogue dialogue)
    {
        if (startTalking)
            return;
        Debug.Log("commence");
        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;
        talking.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            talking.Enqueue(sentence);
        }
        startTalking = true;
        DisplayNextSentence();
    }
    
    // main function and called by the button
    public void DisplayNextSentence ()
    {
        if (talking.Count == 0)
        {
            Debug.Log("test");
            StartCoroutine(EndDialogue());
            return;
        }
        string sentence = talking.Dequeue();
        Debug.Log(sentence + "test");
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    // supposed to print the letters one by one but not really working
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f); 
        }
    }

    IEnumerator EndDialogue()
    {
        animator.SetBool("isOpen", false);
        yield return new WaitForSeconds(0.1f);
        startTalking = false;
    }
}
