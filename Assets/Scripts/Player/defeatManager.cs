using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defeatManager : MonoBehaviour
{
    public string element;
    // Start is called before the first frame update
    void Start()
    {
      switch (element) {
        case "Fire":
            if (GameObject.FindWithTag("Player").GetComponent<PlayerController>().hasDefeatFireBoss)
            {
                foreach (GameObject i in GameObject.FindGameObjectsWithTag("enemy"))
                {
                    Destroy(i);
                }
                Destroy(GameObject.Find("BossFight"));
                }
            break;
        case "Swamp":
            if (GameObject.FindWithTag("Player").GetComponent<PlayerController>().hasDefeatSwampBoss)
            {
                foreach (GameObject i in GameObject.FindGameObjectsWithTag("enemy"))
                {
                    Destroy(i);
                }
                Destroy(GameObject.Find("BossFight"));
            }
            break;
        case "Air":
            if (GameObject.FindWithTag("Player").GetComponent<PlayerController>().hasDefeatAirBoss)
            {
                foreach (GameObject i in GameObject.FindGameObjectsWithTag("enemy"))
                {
                    Destroy(i);
                }
                Destroy(GameObject.Find("BossFight"));
            }
            break;
        case "Water":
            if (GameObject.FindWithTag("Player").GetComponent<PlayerController>().hasDefeatWaterBoss)
            {
                foreach (GameObject i in GameObject.FindGameObjectsWithTag("enemy"))
                {
                    Destroy(i);
                }
                Destroy(GameObject.Find("BossFight"));
            }
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
