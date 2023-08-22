using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] PlayerInventory playerInventoryAmmo;

    [SerializeField] float fireRate = 1f;
    [SerializeField] float StartShootDistance = 10f;
    [SerializeField] int NumberOfEnemes = 0;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootPoint;
    [SerializeField] EnemyFollowPlayer[] Enemy;

    float nextShootTime;
    bool isReloading;
    bool isActive= false;

    [SerializeField] int weaponAmmo;


    private void Start()
    {
        weaponAmmo = 999;
    }

    void Update()
    {
        //TODO edit input from mouse to UI button, just edit "shootAction"

        shootAction();
    }

    private void shootAction()
    {

        if (CanShoot()) //Input.GetKeyDown(KeyCode.Mouse1) 
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
       System.Random r = new System.Random();
        int num = r.Next(0, NumberOfEnemes);
        return
            Time.time >= nextShootTime
            && isReloading == false && weaponAmmo>0 
            && Enemy[num].GetDistanceToTarget() <= StartShootDistance 
            && isActive;
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(1);
        isReloading = false;
        int tempAmmo = 15 - weaponAmmo;
        playerInventoryAmmo.EditBulletInventory(tempAmmo) ;
        weaponAmmo = 15;

    }

  public  void setIsActive(bool b)
    {
        isActive = b;
    }
    public bool getIsActive()
    {
        return isActive;
    }
}

