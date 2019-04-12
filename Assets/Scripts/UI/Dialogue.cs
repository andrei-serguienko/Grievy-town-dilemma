using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue : MonoBehaviour
{
	public string name;

	public int currentStep;

	public DialogText [] sentences;

	private void Start()
	{
		if (GameObject.FindWithTag("Player").GetComponent<PlayerController>().hasDefeatAirBoss)
		{
			currentStep =;
		}if (GameObject.FindWithTag("Player").GetComponent<PlayerController>().hasDefeatFireBoss)
		{
			currentStep =;
		}if (GameObject.FindWithTag("Player").GetComponent<PlayerController>().hasDefeatWaterBoss)
		{
			currentStep =;
		}if (GameObject.FindWithTag("Player").GetComponent<PlayerController>().hasDefeatSwampBoss)
		{
			currentStep =;
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
