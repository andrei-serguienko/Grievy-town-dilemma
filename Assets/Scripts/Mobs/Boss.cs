using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{


	public int speed;
	public float FireRate;
	public Rigidbody2D projectile;
	public Transform[] points;
	public Rigidbody2D Minion;
	public bool spawnTest;

	private Vector3 velocity = Vector3.zero;

	bool started = false;
	bool pos1 = false;
	bool pos2 = false;
	bool pos3 = false;



	// Use this for initialization
	void Start () {
//		InvokeRepeating("throwProjectile", FireRate, 0.4f);
	}

	private void FixedUpdate()
	{
//        Debug.Log("pos1" + pos1);
//        Debug.Log("pos2" + pos2);



		checkDeath();

		if (spawnTest)
		{
			InvokeMinion();
			spawnTest = false;
		}

	}

	void checkDeath()
	{
		if (gameObject.GetComponent<Health>().LifePoints <= 0)
		{
			GameObject.FindWithTag("Player").GetComponent<PlayerController>().defeatBoss(gameObject.name);
		}
	}

	void InvokeMinion()
	{
		var minion1Pos = transform.position;
		var minion2Pos = transform.position;
		var minion3Pos = transform.position;

		minion1Pos.x -= 2;
		minion1Pos.y -= 3;
		minion2Pos.y -= 3;
		minion3Pos.x += 2;
		minion3Pos.y -= 3;

		// print("Minion Spawn");
		Instantiate(Minion, minion1Pos, Quaternion.identity);
		Instantiate(Minion, minion2Pos, Quaternion.identity);
		Instantiate(Minion, minion3Pos, Quaternion.identity);
	}

	void throwProjectile()
	{
		Instantiate(projectile, transform.position, transform.rotation);
	}

}
