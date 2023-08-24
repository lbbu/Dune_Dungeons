using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectWeapons : MonoBehaviour
{
    [SerializeField] WeaponSwitcher weaponSwitcher ;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("Collision!");

            weaponSwitcher.AddWeapon(collision);
            
            Destroy(collision.gameObject);
        }

        


    }
}
