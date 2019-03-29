﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{

    
    public float moveSpeed = 1f;
    public Transform target;
    public float detectionRange = 4f;
    public int lifePoint = 100;
//    public int armorPoint = 0;
    
    private bool moveTowardsPlayer = false;
    private bool HittedByPlayer = false;



    // Use this for initialization
    void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }
	
    // Update is called once per frame
    void Update () {
		
        if (lifePoint <= 0)
        {
            Destroy(gameObject);
        }
        
        // if the Player is near enough, the enemy will move towards him
        float distToPlayer = Vector3.Distance(target.position, transform.position);
        if (distToPlayer < detectionRange || HittedByPlayer)
        {
            moveTowardsPlayer = true;
        }

        if (moveTowardsPlayer == true)
        {
            transform.position = Vector2.MoveTowards( transform.position, target.position, moveSpeed*Time.deltaTime);	
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("playerProjectile"))
        {	
            lifePoint -= col.gameObject.GetComponent<castSpell>().damages;
            HittedByPlayer = true;
//            Debug.Log(lifePoint);
            
            Invoke("resetVelocity", 1.1f);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {	
            FindObjectOfType<PlayerHealth>().TakeAHit(1);
        }
    }

    void resetVelocity()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        Debug.Log("no velo");
    }
}