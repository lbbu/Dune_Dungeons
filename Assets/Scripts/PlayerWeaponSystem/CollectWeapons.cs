using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectWeapons : MonoBehaviour
{
    [SerializeField] WeaponSwitcher weaponSwitcher ;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("weapon1"))
        {

            weaponSwitcher.AddWeapon(collision);
            // collision.gameObject.SetActive(false);
            Destroy(this.GetComponent<CollectWeapons>());
            Destroy(collision.gameObject);

        }




    }
}
