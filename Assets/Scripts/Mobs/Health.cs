using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int LifePoints;
    public int GivenGold;
    public AudioClip Coins;

    private AudioSource audio;

    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (LifePoints <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().money += GivenGold;
            audio.clip = Coins;
            audio.Play();
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("playerProjectile"))
        {
            LifePoints -= other.gameObject.GetComponent<castSpell>().damages;
        }
		
    }
    
}
