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
    public Rigidbody2D basicSpell;
    public Rigidbody2D fireBall;
    public Rigidbody2D waterWall;
    public Rigidbody2D rockPillar;
    public GameObject tornado;
    public float tornadoSpread;
    public int HealingPotion;
    public int ManaPotion;
    public AudioClip ChangeSpell;
    public AudioClip HealingPotionClip;
    public AudioClip ManaPotionClip;
    public AudioClip BuyPotion;
    public AudioClip Step1;
    public AudioClip Step2;
    


    private float HorizontalInput = 0f;
    private float VerticalInput = 0f;
    private Animator anim;
    private AudioSource audio;

    public bool hasDefeatFireBoss;
    public bool hasDefeatAirBoss;
    public bool hasDefeatWaterBoss;
    public bool hasDefeatSwampBoss;

    public Transform seaCheckPoint;
    public bool isTriggCheckPoint = false;

    public int Spell = 0;

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
//        print(gameObject.GetComponent<Rigidbody2D>().velocity);

        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");

        transform.eulerAngles = new Vector3(0, 0, 0);

        if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
        {
            CastBasicSpell();
        }
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if(Spell == 1)
            {
                CastRockPillar();
            } else if (Spell == 2){
                CastWaterWall();
            } else if (Spell == 3){
                CastFireBall();
            } else if (Spell == 4){
                castTornado();
            }
        }


        if(Input.GetKeyDown(KeyCode.Alpha1)  && hasDefeatSwampBoss){
            if (Spell == 2 && hasDefeatWaterBoss){
                GameObject.Find("Canvas/Water").GetComponent<Image>().color = new Color(77,77,77,255);

            }
            else if (Spell == 3 && hasDefeatFireBoss){
                GameObject.Find("Canvas/Fire").GetComponent<Image>().color = new Color(77,77,77,255);

            }
            else if (Spell == 4 && hasDefeatAirBoss){
                GameObject.Find("Canvas/Air").GetComponent<Image>().color = new Color(77,77,77,255);
            }
            Spell = 1;
            ChangeSpellSound();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2) && hasDefeatWaterBoss){
            if(Spell == 1 && hasDefeatSwampBoss){
                GameObject.Find("Canvas/Rock").GetComponent<Image>().color = new Color(77,77,77,255);

            } else if (Spell == 3 && hasDefeatFireBoss){
                GameObject.Find("Canvas/Fire").GetComponent<Image>().color = new Color(77,77,77,255);

            }
            else if (Spell == 4 && hasDefeatAirBoss){
                GameObject.Find("Canvas/Air").GetComponent<Image>().color = new Color(77,77,77,255);
            }
            Spell = 2;
            ChangeSpellSound();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3) && hasDefeatFireBoss){
            if(Spell == 1 && hasDefeatSwampBoss){
                GameObject.Find("Canvas/Rock").GetComponent<Image>().color = new Color(77,77,77,255);

            } else if (Spell == 2 && hasDefeatWaterBoss){
                GameObject.Find("Canvas/Water").GetComponent<Image>().color = new Color(77,77,77,255);

            }
            else if (Spell == 4 && hasDefeatAirBoss){
                GameObject.Find("Canvas/Air").GetComponent<Image>().color = new Color(77,77,77,255);
            }
            Spell = 3;
            ChangeSpellSound();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha4) && hasDefeatAirBoss){
            if(Spell == 1 && hasDefeatSwampBoss){
                GameObject.Find("Canvas/Rock").GetComponent<Image>().color = new Color(77,77,77,255);

            } else if (Spell == 2 && hasDefeatWaterBoss){
                GameObject.Find("Canvas/Water").GetComponent<Image>().color = new Color(77,77,77,255);

            }
            else if (Spell == 3 && hasDefeatFireBoss){
                GameObject.Find("Canvas/Fire").GetComponent<Image>().color = new Color(77,77,77,255);

            }

            Spell = 4;
            ChangeSpellSound();
        }


        if(hasDefeatAirBoss){
            GameObject.Find("Canvas/Air").GetComponent<Image>().color = new Color(77,77,77,255);
        } if (hasDefeatFireBoss){
            GameObject.Find("Canvas/Fire").GetComponent<Image>().color = new Color(77,77,77,255);
        }
        if (hasDefeatSwampBoss){
            GameObject.Find("Canvas/Rock").GetComponent<Image>().color = new Color(77,77,77,255);
        }
        if (hasDefeatWaterBoss){
            GameObject.Find("Canvas/Water").GetComponent<Image>().color = new Color(77,77,77,255);
        }


        // use Heal Potion
        float lifePoints =  this.GetComponent<PlayerHealth>().LifePoints;
        int numberOfHeart = this.GetComponent<PlayerHealth>().numOfHeart;
        if (Input.GetKeyDown("q") && HealingPotion > 0 && lifePoints < numberOfHeart)
        {
            HealingPotion -= 1;
            this.GetComponent<PlayerHealth>().Heal(1);
            audio.clip = HealingPotionClip;
            audio.Play();
            if (lifePoints > numberOfHeart)
                lifePoints = numberOfHeart;
        }
        
        if (Input.GetKeyDown("r") && ManaPotion > 0 && mana < 90)
        {
            ManaPotion -= 1;
            mana += 50;
            audio.clip = ManaPotionClip;
            audio.Play();
            if (mana > 100)
                mana = 100;
        }

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
            

        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        
    }

    void CastBasicSpell()
    {
        if (mana > 0)
        {
            // repositioning fireball with player sprite
            var position = transform.position;
            position[0] += 0.4f;
            position[1] -= 0.6f;
            Instantiate(basicSpell, position, transform.rotation);
            mana -= 5;
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

    void CastRockPillar()
    {
        if (mana > 0)
        {
            var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 10;
            Instantiate(rockPillar, position, Quaternion.identity);
            mana -= 10;
        }
    }

    void castTornado()
    {
        var position = transform.position;

        tornado.GetComponent<castSpell>().angleVariation = tornadoSpread;
        Instantiate(tornado, position, Quaternion.identity);

        tornado.GetComponent<castSpell>().angleVariation = 0;
        Instantiate(tornado, position, Quaternion.identity);

        tornado.GetComponent<castSpell>().angleVariation = -tornadoSpread;
        Instantiate(tornado, position, Quaternion.identity);
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
        HealingPotion += 1;
        audio.clip = BuyPotion;
        audio.Play();
    }
    public void buyPotionMana(){
        ManaPotion += 1;
        audio.clip = BuyPotion;
        audio.Play();
    }

    void OnCollisionEnter2D(Collision2D col){
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
    void OnCollisionExit2D(Collision2D col){

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

    void ChangeSpellSound()
    {
        audio.clip = ChangeSpell;
        audio.Play();
    }

    public void PlayStep1()
    {
        audio.clip = Step1;
        audio.Play();
        print("bite");
    }
    public void PlayStep2()
    {
        audio.clip = Step2;
        audio.Play();
        print("pute");
    }
}