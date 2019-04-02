using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{

	public int health;
	public int damage;
	public Rigidbody2D fireBall;
	public int speed;

	public Transform[] points;
	private Vector3 velocity = Vector3.zero;

	bool started = false;
	bool pos1 = false;
	bool pos2 = false;
	bool pos3 = false;

	public float speedball;


	// Use this for initialization
	void Start () {
		InvokeRepeating("lunchProjectile", 2, 0.4f);
	}

	private void Update()
	{
//        Debug.Log("pos1" + pos1);
//        Debug.Log("pos2" + pos2);
        if (transform.position == points[0].position)
        {
            started = true;
            pos2 = false;
            pos3 = false;
            pos1 = true;
        }
        else if (transform.position == points[1].position)
        {
            pos1 = false;
            pos2 = true;
            pos3 = false;
        } else if (transform.position == points[2].position)
        {
            pos1 = false;
            pos2 = false;
            pos3 = true;
        }

            if (!started)
		{
            //gameObject.transform.position = Vector3.SmoothDamp(transform.position, points[0].position, ref velocity, 1f);
//			Debug.Log("1");
            gameObject.transform.position = Vector3.MoveTowards(transform.position, points[0].position, speed * Time.deltaTime);
        }

		if (pos1)
		{
            //gameObject.transform.position = Vector3.SmoothDamp(transform.position, points[1].position, ref velocity, 1f);
//			Debug.Log("2");
            gameObject.transform.position = Vector3.MoveTowards(transform.position, points[1].position, speed * Time.deltaTime);

        }
        if (pos2)
		{
            //gameObject.transform.position = Vector3.SmoothDamp(transform.position, points[0].position, ref velocity, 1f);
//			Debug.Log("3");
            gameObject.transform.position = Vector3.MoveTowards(transform.position, points[2].position, speed * Time.deltaTime);

        }
        if (pos3)
        {
            //gameObject.transform.position = Vector3.SmoothDamp(transform.position, points[0].position, ref velocity, 1f);
//	        Debug.Log("4");
            gameObject.transform.position = Vector3.MoveTowards(transform.position, points[0].position, speed * Time.deltaTime);

        }

		checkDeath();

	}

	void checkDeath()
	{
		if (health <= 0)
		{
			GameObject.FindWithTag("Player").GetComponent<PlayerController>().defeatBoss(gameObject.name);
			Destroy(gameObject);
		}
	}

	void lunchProjectile()
	{
		Instantiate(fireBall, transform.position, transform.rotation);
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag.Equals("playerProjectile"))
		{
			health -= 1;
		}
		else
		{
			Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());

		}
	}
}
