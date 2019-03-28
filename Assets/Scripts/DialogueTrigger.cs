using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

  public bool isDialoguing = false;

    public Dialogue dialogue;

    public void TriggerDialogue(bool startStop)
    {
        if (startStop == true)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            isDialoguing = true;
        }
        else
        {
            Debug.Log("Fermer");
            FindObjectOfType<DialogueManager>().EndDialogue();
            isDialoguing = false;
        }
    }

}
