﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public Animator animator;

    private string product;

    private Queue<string> sentences;

    // Use this for initialization
    void Start () {
        sentences = new Queue<string>();
    }

    private void Update()
    {
    }

    public void StartDialogue(Dialogue dialogue, string product)
    {
       GameObject.FindWithTag("Player").GetComponent<PlayerController>().isDialoguing = true;
       this.product = product;
       animator.SetBool("isOpen", true);

      nameText.text = dialogue.name;
      sentences.Clear();

        foreach (DialogText sentence in dialogue.sentences)
        {
            Debug.Log(sentence.texte);
            if(sentence.step == dialogue.currentStep)
            {
              sentences.Enqueue(sentence.texte);
            }
        }
        DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
//        Debug.Log("next sentence");
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().isDialoguing = false;
        animator.SetBool("isOpen", false);
    }

    public void buy(){
      print(product);
      PlayerController player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
      if(player.money < 50){
        return;
      }

      if(product == "Health")
      {
        player.buyPotionHealth();
        GameObject.FindWithTag("AnimPotionHealth").GetComponent<Animator>().SetTrigger("Buying");
      } else if (product == "Mana"){
        player.buyPotionMana();
        GameObject.FindWithTag("AnimPotionMana").GetComponent<Animator>().SetTrigger("Buying");
      }
      player.money -= 50;
    }

}
