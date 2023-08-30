using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision!");

        switch (collision.gameObject.tag)
        {
            case "GoldKey":
                Debug.Log("get Gold Key");
                Destroy(collision.gameObject);
                break;

        }

    }

    void AddGoldKey()
    {

    }
}
