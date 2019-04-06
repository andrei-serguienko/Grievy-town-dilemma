using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwampBoss : MonoBehaviour
{
    Health hp;
    bool ulti1 = false;
    bool ulti2 = false;
    bool ulti3 = false;
    bool ulti4 = false;
    // Start is called before the first frame update
    void Start()
    {
        hp = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
      if(hp.LifePoints < (0.8 * (float)hp.maxHealth) && !ulti1){
          print("Ulti1");
          GetComponent<Animator>().SetTrigger("Ulti");
          ulti1 = true;
      }
      if(hp.LifePoints < (0.6 * (float)hp.maxHealth) && !ulti2){
          print("Ulti1");
          GetComponent<Animator>().SetTrigger("Ulti");
          ulti2 = true;
      }
      if(hp.LifePoints < (0.4 * (float)hp.maxHealth) && !ulti3){
          print("Ulti1");
          GetComponent<Animator>().SetTrigger("Ulti");
          ulti3 = true;
      }
      if(hp.LifePoints < (0.2 * (float)hp.maxHealth) && !ulti4){
          print("Ulti1");
          GetComponent<Animator>().SetTrigger("Ulti");
          ulti4 = true;
      }
    }




}
