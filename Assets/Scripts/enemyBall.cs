using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBall : MonoBehaviour {
    public float speed = 10f;
    public Vector3 direction;
    private GameObject player;




    private void Start()
    {
        player = GameObject.FindWithTag("Player");
//        Debug.Log(player);
        var pos = this.gameObject.transform.position;
        var dir = player.transform.position - pos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Vector2 direction = dir;
        direction.Normalize();
        //GameObject projectile = (GameObject)Instantiate(, pos, Quaternion.identity);
        this.gameObject.GetComponent<Rigidbody2D>().velocity = direction * speed;

        Destroy(gameObject, 2.0f);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
//            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            player.GetComponent<PlayerHealth>().TakeAHit(0.5f);
            Destroy(gameObject);
            player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            player.GetComponent<Rigidbody2D>().AddForce(Vector3.zero);

        }
        else if (col.gameObject.tag.Equals("Boss"))
        {
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        }
        else
        {
            Destroy(gameObject);
        }
        
         
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 3 * Time.deltaTime);
    }
    
    
}
