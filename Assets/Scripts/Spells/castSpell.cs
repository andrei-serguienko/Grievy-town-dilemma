using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class castSpell : MonoBehaviour
{
    public int damages;
    public float speed;
    public float destroyTime;
    public Vector3 direction;
    private Animator anim;
    private AudioSource audio;


    private void Awake()
    {

    }

    private void Start()
    {
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

        Vector2 direction = dir;
        direction.Normalize();
        //GameObject projectile = (GameObject)Instantiate(, pos, Quaternion.identity);
        this.gameObject.GetComponent<Rigidbody2D>().velocity = direction * speed;

        Destroy(gameObject, destroyTime);

        audio.Play();

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Destroy the projectile when it hit something
        destroyProjectile();
    }

    public void destroyProjectile()
    {
        string objectName = this.gameObject.name;
        objectName = objectName.Substring(0, objectName.Length - 7);
        
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        
        if (objectName == "fireball" || objectName == "BasicSpell")
        {
            anim.SetBool("destroy", true);
            print(anim.GetParameter(0));
            Destroy(this.gameObject, 0.3f);
        }
    }

    
}

//