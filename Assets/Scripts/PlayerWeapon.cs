using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] PlayerInventory playerInventoryAmmo;

    [SerializeField] float fireRate = 1f;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootPoint;
    
    float nextShootTime;
    bool isReloading;

    [SerializeField] int weaponAmmo;


    private void Start()
    {
        weaponAmmo = 15;
    }

    void Update()
    {
        //TODO edit input from mouse to UI button, just edit "shootAction"

        shootAction();
    }

    private void shootAction()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1) && CanShoot())
        {
            shoot();
        }


        if (Input.GetKey(KeyCode.R) && !isReloading)
        {
            StartCoroutine(Reload());
        }

    }

    private void shoot()
    {
        nextShootTime = Time.time + 1 / fireRate;
        Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        weaponAmmo--;
    }

    bool CanShoot()
    {
        return
            Time.time >= nextShootTime &&
            isReloading == false && weaponAmmo>0 ;
    }

    IEnumerator Reload()
    {
        Debug.Log("reload?????");

        isReloading = true;
        yield return new WaitForSeconds(1);
        isReloading = false;
        int tempAmmo = 15 - weaponAmmo;
        playerInventoryAmmo.EditBulletInventory(tempAmmo) ;
        weaponAmmo = 15;

    }

}
