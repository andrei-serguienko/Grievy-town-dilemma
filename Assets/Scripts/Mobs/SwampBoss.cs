using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwampBoss : MonoBehaviour
{
    Health hp = GetComponent<Health>();
    bool ulti1 = false;
    bool ulti2 = false;
    bool ulti3 = false;
    bool ulti4 = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(hp.LifePoints % 25 == 0){

      }
    }
}
