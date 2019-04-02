using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
	
	public float detectionRange = 1f;
    //public GameObject player;
  public string Name;

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
//            Debug.Log("blop");
			DialogueOn = true;
			gameObject.GetComponent<DialogueTrigger>().TriggerDialogue(true);

			// call to trading function here

		}
		if (distToPlayer > detectionRange && DialogueOn) // && DialogueOn == true
        {
			gameObject.GetComponent<DialogueTrigger>().TriggerDialogue(false);
//            Debug.Log("out of zone");
			DialogueOn = false;

		}



	}
}
