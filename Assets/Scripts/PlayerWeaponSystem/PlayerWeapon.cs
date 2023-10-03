using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerWeapon : MonoBehaviour
{

    public static event System.Action ShootingEvent;


    [SerializeField] float fireRate = 1f;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootPoint;
    [SerializeField] PlayerMovements PlayerMovement ;
    [SerializeField] FacingEnemy facingEnemy;

    float nextShootTime;

    bool isActive= false;
    bool isWalking = false;
    bool isListEmpty = false;
    bool isShooting;

    

    Transform closestEnemy;
    List<Transform> nearbyEnemies = new List<Transform>();
    [SerializeField] GameObject AllEnemys;



    void Update()
    {

        nearbyEnemies = facingEnemy.nearbyEnemies;
       isListEmpty = facingEnemy.GetIsEmptyListOfEnemys();
        isWalking = PlayerMovement.IsWalking();
        ShootAction();
    }

    private void ShootAction()
    {

        if (CanShoot())
        {
            Shoot();
            isShooting = true;
            ShootingEvent?.Invoke();

        }
        else
        {
            isShooting = false;
        }

    }

    
    

    public bool IsShooting() => isShooting;
    private void Shoot()
    {
        if (Time.time >= nextShootTime)
        {
            nextShootTime = Time.time + 1 / fireRate;
            Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        }

    }

    bool CanShoot()
    {

        return
             isActive
            && !isWalking
            && !isListEmpty
            && facingEnemy.closestEnemy != null;
    }

    public bool GetIsEmptyListOfEnemys()
    {
        if ( AllEnemys.transform.childCount == 0)
            return true;
        return false;
    }
    public  void SetIsActive(bool active)
    {
        isActive = active;
    }
    public bool GetIsActive()
    {
        return isActive;
    }
}

