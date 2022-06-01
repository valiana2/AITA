using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DialogueMana : MonoBehaviour
{
    private Text nameText;
    private Text dialogueText;
    private bool startTalking = false;
    private Animator animator;

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

    public void StartDialogue (Dialogue dialogue, Text dialogue_Text, Text name_Text, Animator _animator)
    {
        if (startTalking)
            return;
        animator.SetBool("isOpen", true);
        dialogueText = dialogue_Text;
        nameText = name_Text;
        animator = _animator;
        nameText.text = dialogue.name;
        talking.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            talking.Enqueue(sentence);
        }
        startTalking = true;
    }
    
    // main function and called by the button
    public void DisplayNextSentence ()
    {
        if (talking.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = talking.Dequeue();
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

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        startTalking = false;
    }
}
