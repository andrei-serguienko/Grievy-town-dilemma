using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
	
    public float detectionRange = 1f;public bool hasSpoken;

    private bool DialogueOn = false;
    private Transform target;
   


    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        

    }

    // Update is called once per frame
    void Update () {

        // if the Player is near enough, the enemy will move towards him
        float distToPlayer = Vector3.Distance(target.position, transform.position);
        if (distToPlayer < detectionRange && Input.GetKeyDown("e"))
        {
			
            DialogueOn = true;
            gameObject.GetComponent<DialogueTrigger>().TriggerDialogue(true);
            
            


        }
        if (distToPlayer > detectionRange && DialogueOn)
        {
            gameObject.GetComponent<DialogueTrigger>().TriggerDialogue(false);
            DialogueOn = false;
        }



    }
}