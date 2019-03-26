using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    private float delay;
    public float TimeDelay;

    public GameObject dashEffect;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        print(delay);
        if(direction == 0){
          // if(gameObject.GetComponent<PlayerController>().getHorizontalInput() < 0)
          print("SPACE");
          if(Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.Space) && delay <= 0)
          {
            direction = 1;
            Instantiate(dashEffect, transform.position + new Vector3(0,0, -10), Quaternion.identity);
          // } else if(gameObject.GetComponent<PlayerController>().getHorizontalInput() > 0)
          } else if(Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.Space) && delay <= 0)
          {
            direction = 2;
            Instantiate(dashEffect, transform.position + new Vector3(0,0, -10), Quaternion.identity);
          }
          // else if(gameObject.GetComponent<PlayerController>().getVerticalInput() > 0)
          else if(Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.Space) && delay <= 0)
          {
            direction = 3;
            Instantiate(dashEffect, transform.position + new Vector3(0,0, -10), Quaternion.identity);
          }
          // else if(gameObject.GetComponent<PlayerController>().getVerticalInput() < 0)
          else if(Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.Space) && delay <= 0)
          {
            direction = 4;
            Instantiate(dashEffect, transform.position + new Vector3(0,0, -10), Quaternion.identity);
          }
        } else {
          if(dashTime <= 0)
          {
            // gameObject.GetComponent<PlayerController>().canMove = true;
            direction = 0;
            dashTime = startDashTime;
            rb.velocity = Vector2.zero;
            // Invoke("resetVelocity", 0.5f);
          }else {
            dashTime -= Time.deltaTime;
            // gameObject.GetComponent<PlayerController>().canMove = false
            if(direction == 1){
              rb.velocity = Vector2.left * dashSpeed;
              delay = TimeDelay;
            } else if(direction == 2){
              rb.velocity = Vector2.right * dashSpeed;
              delay = TimeDelay;
            } else if(direction == 3){
              rb.velocity = Vector2.up * dashSpeed;
              delay = TimeDelay;
            } else if(direction == 4){
              rb.velocity = Vector2.down * dashSpeed;
              delay = TimeDelay;
            }
          }
        }
        delay -= Time.deltaTime;
    }

}
