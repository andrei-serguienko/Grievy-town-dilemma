﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPointZone : MonoBehaviour
{
    public string name;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other){
      if(other.gameObject.tag == "Player"){
        other.gameObject.GetComponent<PlayerController>().seaCheckPoint = GameObject.Find(name).transform;
      }
    }
}