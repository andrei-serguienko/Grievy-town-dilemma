using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossApparition : MonoBehaviour
{

	public GameObject boss;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
//		Debug.Log("ww" + GameObject.FindWithTag("enemy"));
		if (GameObject.FindWithTag("enemy") == null)
		{
			boss.SetActive(true);
		}
	}
}
