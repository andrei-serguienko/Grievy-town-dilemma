using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue : MonoBehaviour
{
	public string name;

	public int currentStep;

	public DialogText [] sentences;

	public bool tuto = false;

	private void Start()
	{
		if (GameObject.FindWithTag("Player").GetComponent<PlayerController>().hasDefeatAirBoss)
		{
			currentStep = 6;
		}if (GameObject.FindWithTag("Player").GetComponent<PlayerController>().hasDefeatFireBoss)
		{
			currentStep = 4;
		}if (GameObject.FindWithTag("Player").GetComponent<PlayerController>().hasDefeatWaterBoss)
		{
			currentStep = 3;
		}if (GameObject.FindWithTag("Player").GetComponent<PlayerController>().hasDefeatSwampBoss)
		{
			currentStep = 5;
		}
	}

	private void Update()
	{
		if (name == "Houx")
		{
			GameObject.FindWithTag("Player").GetComponent<PlayerController>().houxStep = currentStep;
		}
	}
}
