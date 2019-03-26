using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int mana = 100;
    private Slider manaUI;

    public string origin;
    public float moveSpeed;
    public bool canMove;
    private float currentMoveSpeed;
    public Rigidbody2D fireBall;
    public Rigidbody2D waterWall;
    public int HealingPotion;

    private float HorizontalInput = 0f;
    private float VerticalInput = 0f;

    // Use this for initialization
    void Start()
    {
        origin = "Menu";
        manaUI = GameObject.FindWithTag("Mana").GetComponent<Slider>();
        InvokeRepeating("regenMana", 0, 0.2f);
    }

    public string getOrigin()
    {
        return origin;
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");

        print(HorizontalInput);
        print(VerticalInput);
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


        if (Input.GetMouseButtonDown(1))
        {
            CastFireBall();
        }
        if (Input.GetMouseButtonDown(0))
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
//            position[0] += 0.4f;
//            position[1] -= 0.6f;
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

}
