using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMerchant : MonoBehaviour
{
    bool canBuy = false;



    // Update is called once per frame
    void Update()
    {
      canBuy = gameObject.GetComponent<DialogueTrigger>().isDialoguing;
      if(canBuy && Input.GetKeyDown(KeyCode.B))
      {
        print("ACHETER");
      }
    }
}
