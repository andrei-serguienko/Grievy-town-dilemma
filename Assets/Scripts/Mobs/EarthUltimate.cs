using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthUltimate : MonoBehaviour
{

    public bool ActiveUltimate;
    public float Delay;
    public GameObject FirstRing;
    public GameObject SecondRing;
    public GameObject ThirdRing;
    public GameObject FourthRing;
    public GameObject FifthRing;
    public GameObject SixthRing;
    public GameObject SeventhRing;

    private void Update()
    {
        //check boss Health here -> ActivateUlti = true;
        
        if (ActiveUltimate)
        {
            StartCoroutine(Ultimate());
            ActiveUltimate = false;
        }
    }
    
    private IEnumerator Ultimate()
    {
        print("Ultimate");
        Instantiate(FirstRing);
        yield return new WaitForSeconds(Delay);
        Instantiate(SecondRing);
        yield return new WaitForSeconds(Delay);
        Instantiate(ThirdRing);
        yield return new WaitForSeconds(Delay);
        Instantiate(FourthRing);
        yield return new WaitForSeconds(Delay);
        Instantiate(FifthRing);
        yield return new WaitForSeconds(Delay);
        Instantiate(SixthRing);
        yield return new WaitForSeconds(Delay);
        Instantiate(SeventhRing);
        
        yield return new WaitForSeconds(3);
        foreach(GameObject i in GameObject.FindGameObjectsWithTag("EarthRing"))
        {
            Destroy(i);
        }
    }
}
