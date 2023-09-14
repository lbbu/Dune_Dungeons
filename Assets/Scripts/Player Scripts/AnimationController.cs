using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] PlayerMovements playerMovement;
    [SerializeField] WeaponSwitcher WeaponHandler;
    [SerializeField] List<GameObject> weapons = new List<GameObject>();

    int SelectedWeapon;
    void Start()
    {
        
           
        
    }


    void Update()
    {
        SelectedWeapon= WeaponHandler.GetSelectedWeapon();


            if (playerMovement.IsWalking())
            {
                GetComponent<Animator>().SetBool("walk", true);
            }
            else if (!playerMovement.IsWalking())
            {
                GetComponent<Animator>().SetBool("walk", false);
            }

        Debug.Log("SelectedWeapon "+SelectedWeapon);


        Debug.Log("WeaponsCount " + weapons.Count);

        if (SelectedWeapon >= 0 && SelectedWeapon < weapons.Count)
        {
            if (weapons[SelectedWeapon].GetComponent<PlayerWeapon>().IsShooting())
            {
                GetComponent<Animator>().SetBool("shoot", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("shoot", false);
            }
        }
        

    }
}
