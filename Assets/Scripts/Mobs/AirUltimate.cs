using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirUltimate : MonoBehaviour, InterfaceSpell
{
    public bool ActiveUltimate;
    public float Delay;

    public GameObject Tornado;
    
  
    // Update is called once per frame
    void Update()
    {
        Transform pos = transform;
        
        if (ActiveUltimate)
        {
            StartCoroutine(Ultimate());
            ActiveUltimate = false;
        }
    }
    
    
    private IEnumerator Ultimate()
    {
        var pos = transform.position;
        
        Instantiate(Tornado, pos, Quaternion.identity);
        yield return new WaitForSeconds(Delay);
        Instantiate(Tornado, pos, Quaternion.identity);
        yield return new WaitForSeconds(Delay);
        Instantiate(Tornado, pos, Quaternion.identity);
        yield return new WaitForSeconds(Delay);
        Instantiate(Tornado, pos, Quaternion.identity);
        yield return new WaitForSeconds(Delay);
        Instantiate(Tornado, pos, Quaternion.identity);
        yield return new WaitForSeconds(Delay);
        Instantiate(Tornado, pos, Quaternion.identity);
        yield return new WaitForSeconds(Delay);
        Instantiate(Tornado, pos, Quaternion.identity);
        yield return new WaitForSeconds(Delay);
        Instantiate(Tornado, pos, Quaternion.identity);
        yield return new WaitForSeconds(Delay);
        Instantiate(Tornado, pos, Quaternion.identity);
        yield return new WaitForSeconds(Delay);
        Instantiate(Tornado, pos, Quaternion.identity);
        yield return new WaitForSeconds(Delay);
        
    }

    public void ActivateUltimateF()
    {
        ActiveUltimate = true;
    }
}
