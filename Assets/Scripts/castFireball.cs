using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castFireball : MonoBehaviour
{
    
    public float speed = 10f;
    public Vector3 direction;

    private void Awake()
    {
        
    }

    private void Start()
    {
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
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
            Physics2D.IgnoreCollision( col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>() );
   
        }
        //Destroy the projectile when it hit something
        if (!col.gameObject.tag.Equals("Player"))
        {	
            Destroy(gameObject);
        }
    }
    
}

//
