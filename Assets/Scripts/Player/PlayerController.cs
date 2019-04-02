﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PlayerController : MonoBehaviour
{
    public int money;
    public int mana = 100;
    private Slider manaUI;

    public string origin;
    public float moveSpeed;
    public bool canMove;
    private float currentMoveSpeed;
    public Rigidbody2D fireBall;
    public Rigidbody2D waterWall;
    public int HealingPotion;
    public int ManaPotion;
    public AudioClip step;


    private float HorizontalInput = 0f;
    private float VerticalInput = 0f;
    private Animator anim;
    AudioSource audio;


    public bool hasDefeatFireBoss;
    public bool hasDefeatAirBoss;
    public bool hasDefeatWaterBoss;
    public bool hasDefeatSwampBoss;



    // Use this for initialization
    void Start()
    {
      // event = GameObject.Find("EventSystem")
        origin = "Menu";
        manaUI = GameObject.FindWithTag("Mana").GetComponent<Slider>();
        InvokeRepeating("regenMana", 0, 0.2f);
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

    }

    public string getOrigin()
    {
        return origin;
    }

    // Update is called once per frame
    void Update()
    {
        print(gameObject.GetComponent<Rigidbody2D>().velocity);
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");

        transform.eulerAngles = new Vector3(0, 0, 0);

    }


    void FixedUpdate()
    {
        manaUI.value = mana;
//        Debug.Log(manaUI);
//        Debug.Log(mana);
      if(canMove)
      {
        if (Mathf.Abs(HorizontalInput) > 0.5f && Mathf.Abs(VerticalInput) > 0.5f)
        {
            currentMoveSpeed = moveSpeed / 1.4f;
        }else
        {
            currentMoveSpeed = moveSpeed;
        }

        if (HorizontalInput > 0.5f)
        {
            transform.Translate(new Vector3(HorizontalInput * currentMoveSpeed * Time.deltaTime, 0f, 0f));

        }
        if (HorizontalInput < 0.5f)
        {
            transform.Translate(new Vector3(HorizontalInput * currentMoveSpeed * Time.deltaTime, 0f, 0f));
        }
        if (VerticalInput > 0.5f)
        {
            transform.Translate(new Vector3(0f, VerticalInput * currentMoveSpeed * Time.deltaTime, 0f));
        }
        if (VerticalInput < 0.5f)
        {
            transform.Translate(new Vector3(0f, VerticalInput * currentMoveSpeed * Time.deltaTime, 0f));
        }
      }

        if (HorizontalInput != 0 || VerticalInput != 0)
        {
            anim.SetBool("isWalking", true);
//            audio.PlayOneShot(step);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (Input.GetMouseButtonDown(1))
        {
            CastFireBall();
        }
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            CastWaterWall();
        }

        // use Heal Potion
        float lifePoints =  this.GetComponent<PlayerHealth>().LifePoints;
        int numberOfHeart = this.GetComponent<PlayerHealth>().numOfHeart;
        if (Input.GetKeyDown("p") && HealingPotion > 0 && lifePoints <numberOfHeart)
        {
            HealingPotion -= 1;
            this.GetComponent<PlayerHealth>().Heal(1);
        }
    }


    void CastFireBall()
    {
        if (mana > 0)
        {
            // repositioning fireball with player sprite
            var position = transform.position;
            position[0] += 0.4f;
            position[1] -= 0.6f;
            Instantiate(fireBall, position, transform.rotation);
            mana -= 5;
        }
    }
    void CastWaterWall()
    {
        if (mana > 0)
        {
            var position = transform.position;
            Instantiate(waterWall, position, transform.rotation);
            mana -= 10;
        }
    }

    void regenMana()
    {
        if (mana < 100)
        {
            mana += 1;
        }

    }

    public float getHorizontalInput(){
      return HorizontalInput;
    }
    public float getVerticalInput(){
      return VerticalInput;
    }

    public void buyPotionHealth(){
      print("PPP");
      HealingPotion += 1;
    }
    public void buyPotionMana(){
      ManaPotion += 1;
    }

    void OnCollisionEnter2D(Collision2D col){
      gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
    void OnCollisionExit2D(Collision2D col){
      print("ColExit");

      gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
      gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.zero);
    }

    public void defeatBoss(string name){
      print(name);
      if (name == "BossFire"){
        print("Defeat Fire");
        hasDefeatFireBoss = true;
      } else if(name == "BossAir"){
        hasDefeatAirBoss = true;
      } else if(name == "BossWater"){
        hasDefeatWaterBoss = true;
      } else if(name == "BossSwamp"){
        hasDefeatSwampBoss = true;
      }
    }

}