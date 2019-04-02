using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castRockPillar : MonoBehaviour
{
    public int damages;
    public float destroyTime;
    private Animator anim;
    private AudioSource audio;

    private void Start()
    {
        var pos = Input.mousePosition;
       
        anim = GetComponent<Animator>();
//        audio = GetComponent<AudioSource>();

        Destroy(gameObject, destroyTime);

//        audio.Play();
    }

    public void destroyProjectile()
    {
        string objectName = this.gameObject.name;
        objectName = objectName.Substring(0, objectName.Length - 7);
        
        if (objectName == "fireball" || objectName == "BasicSpell")
        {
            anim.SetBool("destroy", true);
            print(anim.GetParameter(0));
            Destroy(this.gameObject, 0.3f);
        }
    }    
}
