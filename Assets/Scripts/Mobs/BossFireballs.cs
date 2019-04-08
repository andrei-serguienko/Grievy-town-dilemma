using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFireballs : MonoBehaviour {
    public float speed = 10f;
    public Vector3 direction;
    public float TimeTillDestroy;
    public float dammages;
    public GameObject FireTrail;
    
    private GameObject player;




    private void Start()
    {
        var dir = this.direction;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        direction.Normalize();
        this.gameObject.GetComponent<Rigidbody2D>().velocity = direction * speed;

        Destroy(gameObject, TimeTillDestroy);

    }
    
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 3 * Time.deltaTime);
        
        InvokeRepeating("spawnFireTrail", 0, 0.1f);
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
        else
        {
            Destroy(gameObject);
        }
    }
    
    void spawnFireTrail()
    {
        Instantiate(FireTrail, transform.position, Quaternion.identity);
    }
}