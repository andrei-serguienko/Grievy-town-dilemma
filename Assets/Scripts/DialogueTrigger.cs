using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
  public string product;
  public GameObject buyButton;


    public Dialogue dialogue;

    public void TriggerDialogue(bool startStop)
    {
        if (startStop == true)
        {
          if(product != ""){
            GameObject.Find("Canvas/DialogueBox/Acheter").SetActive(true);
          }
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue, product);
        }
        else
        {
          if(product != ""){
            GameObject.Find("Canvas/DialogueBox/Acheter").SetActive(false);
          }
            FindObjectOfType<DialogueManager>().EndDialogue();
        }
    }

}
