﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBalls : MonoBehaviour
{
    public int lifePoints;
    public float DealtDamages;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lifePoints <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("playerProjectile"))
        {	
            lifePoints --;
        }
        
        if (col.gameObject.tag.Equals("Player"))
        {	
            FindObjectOfType<PlayerHealth>().TakeAHit(1);
        }
    }
}
