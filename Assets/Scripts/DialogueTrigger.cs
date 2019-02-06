using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    public void TriggerDialogue(bool startStop)
    {
        if (startStop == true)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
//            Debug.Log("dialTrigger");
        }
        else
        {
            FindObjectOfType<DialogueManager>().EndDialogue();
        }
    }
    
}
