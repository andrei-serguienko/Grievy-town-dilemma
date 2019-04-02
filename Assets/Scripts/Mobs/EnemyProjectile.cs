using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {
    public float speed = 10f;
    public Vector3 direction;
    public float TimeTillDestroy;
    public float dammages;
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

        Destroy(gameObject, TimeTillDestroy);

    }
    
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 3 * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            player.GetComponent<PlayerHealth>().TakeAHit(dammages);
            Destroy(gameObject);
            player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            player.GetComponent<Rigidbody2D>().AddForce(Vector3.zero);

        }
//        else
//        {
//            Destroy(gameObject);
//        }
        
         
    }

    
    
    
}
