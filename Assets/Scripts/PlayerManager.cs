using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class PlayerManager : MonoBehaviour {
    //public GameObject inventory;
    //public GameObject shop;
    public Image[] Hearts;
    public bool hasTriggerIntroCinematic = false;
    public GameObject introTimeline;

    // Use this for initialization
  void Awake()
  {
        //shop = GameObject.FindWithTag("Shop");
        //shop.SetActive(false);
        //inventory = GameObject.FindWithTag("Inventory");
        //inventory.SetActive(false);
  }
  void Start () {
  }


	// Update is called once per frame
	void Update () {
    
      if(SceneManager.GetActiveScene().name == "Town" && !hasTriggerIntroCinematic)
      {
        introTimeline = GameObject.FindWithTag("TimeLineManager");
        introTimeline.GetComponent<PlayableDirector>().Play();
        hasTriggerIntroCinematic = true;
      }

        //if (Input.GetKeyDown(KeyCode.I) && !inventory.activeSelf)
        //{
        //    inventory.SetActive(true);
        //} else if ((Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Escape)) && inventory.activeSelf) {
        //    inventory.SetActive(false);
        //}

        //if (Input.GetKeyDown(KeyCode.B) && !shop.activeSelf)
        //{
        //    shop.SetActive(true);
        //}
        //else if ((Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.Escape)) && shop.activeSelf)
        //{
        //    shop.SetActive(false);
        //}
    }
}
