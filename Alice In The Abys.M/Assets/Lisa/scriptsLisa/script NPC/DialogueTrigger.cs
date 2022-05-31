using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    public bool isInRange;

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E)) //do not remove the E keyboard touch or it does not work!!!
        {
            TriggerDialogue();
        }
    }
    // detects if Alice is close enought
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO afficher "press E"
        
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueMana>().StartDialogue(dialogue,dialogueText, nameText, animator);
    }







    /*public bool isInRange;

    
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E)
        {
            TriggerDialogue();
        }
        
    }*/
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
        }
    }*/

    /*void TriggerDialogue()
    {
        DialogueManagment.instance.StartDialogue(dialogue);
    }*/
}
