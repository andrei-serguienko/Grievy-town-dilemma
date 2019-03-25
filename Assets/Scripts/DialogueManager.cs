using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public Animator animator;

    private Queue<string> sentences;

    // Use this for initialization
    void Start () {
        sentences = new Queue<string>();
    }

    private void Update()
    {
    }

    public void StartDialogue(Dialogue dialogue)
    {
//        Debug.Log("startDial");

        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (DialogText sentence in dialogue.sentences)
        {
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
        animator.SetBool("isOpen", false);
    }
}
