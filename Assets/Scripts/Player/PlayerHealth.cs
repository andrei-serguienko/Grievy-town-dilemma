﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

	public float LifePoints;
	public int numOfHeart;

	private Image[] Heart;
	public Sprite FullHeart;
	public Sprite HalfHeart;
	public Sprite EmptyHeart;


	void Start()
	{
        //Debug.Log( GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>());
        Heart = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>().Hearts;
//        Debug.Log(Heart);

    }


    // Update is called once per frame
    void Update () {
//        Debug.Log(Heart.Length);
		for (int i = 0; i < Heart.Length; i++)
		{
			if (LifePoints - i == 0.5)
			{
				Heart[i].sprite = HalfHeart;
			}
			else if (i < LifePoints)
			{
				Heart[i].sprite = FullHeart;
			}
			else
			{
				Heart[i].sprite = EmptyHeart;
			}
			
			if (i < numOfHeart)
			{
				Heart[i].enabled = true;
			}
			else
			{
				Heart[i].enabled = false;
			}
		}
		
		if (LifePoints <= 0 )
		{
			Die();
		}
	}

	public void TakeAHit(float damage)
	{	
		if (damage < 0)
		{
			Debug.LogError("pas possible");
			return;
		}
		LifePoints -= damage;
	}

	public void Heal(float heal)
	{
		LifePoints += heal;
	}

	public void Die()
	{
		Destroy(gameObject);
		Destroy(GameObject.FindGameObjectWithTag("UI"));
		Destroy(GameObject.FindGameObjectWithTag("PlayerManager"));
		Destroy(GameObject.FindGameObjectWithTag("DialogManager"));
		SceneManager.LoadScene("GameOver");
	}
}