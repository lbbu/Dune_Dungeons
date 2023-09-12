using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectItems : MonoBehaviour
{

  [SerializeField] PlayerInventory inventory;
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision!");

        switch (collision.gameObject.tag)
        {
            case "GoldKey":
                Debug.Log("get Gold Key");
                inventory.AddGoldKey();
                Destroy(collision.gameObject);
                break;

            case "SelverKey":
                Debug.Log("get Selver Key");
                inventory.AddSelverKey();
                Destroy(collision.gameObject);
                break;

        }

    }

    
}
