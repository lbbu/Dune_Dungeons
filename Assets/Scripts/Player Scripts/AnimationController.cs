using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] PlayerMovements playerMovement;
    [SerializeField] WeaponSwitcher WeaponHandler;
    [SerializeField] List<GameObject> weapons = new List<GameObject>();

    int SelectedWeapon;


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
        
        if(playerHealth.IsDead())
        {
            weapons[SelectedWeapon].GetComponent<PlayerWeapon>().SetIsActive(false);
            GetComponent<Animator>().SetTrigger("death");
        }
        

        if(weapons[SelectedWeapon].GetComponent<PlayerWeapon>().GetIsEmptyListOfEnemys())
        {
           GetComponent<Animator>().SetBool("vectory", true);
           GetComponent<Animator>().SetBool("idle", false );

        }
        else
        {
            GetComponent<Animator>().SetBool("vectory", false);

        }

    }
}
