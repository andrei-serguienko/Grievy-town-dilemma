using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterUlti : MonoBehaviour
{
    public bool ActiveUltimate;
    public float Delay;

    public GameObject FirstWave;
    public GameObject SecondWave;
    public GameObject ThirdWave;
    
   

    // Update is called once per frame
    void Update()
    {
        if (ActiveUltimate)
        {
            StartCoroutine(Ultimate());
            ActiveUltimate = false;
        }
    }

    private IEnumerator Ultimate()
    {
        Transform pos = transform;
        
        Instantiate(FirstWave, pos);
        yield return new WaitForSeconds(Delay);
        Instantiate(SecondWave, pos);
        yield return new WaitForSeconds(Delay);
        Instantiate(ThirdWave, pos);
        yield return new WaitForSeconds(Delay);
        
    }
}
