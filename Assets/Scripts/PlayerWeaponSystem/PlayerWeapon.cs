using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] PlayerInventory playerInventoryAmmo;

    [SerializeField] float fireRate = 1f;
    //[SerializeField] float StartShootDistance = 10f;
    //[SerializeField] int NumberOfEnemes = 0;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootPoint;
    [SerializeField] EnemyFollowPlayer[] Enemy;
    [SerializeField] PlayerMovements PlayerMovement ;
    [SerializeField] FacingEnemy facingEnemy;
    float nextShootTime;
    bool isActive= false;
    bool isWalking = false;
    bool isListEmpty = false;

   


    private void Start()
    {
        
    }

    void Update()
    {
        //TODO edit input from mouse to UI button, just edit "shootAction"
       isListEmpty = facingEnemy.GetIsEmptyListOfEnemys();
        isWalking = PlayerMovement.IsWalking();
        shootAction();
    }

    private void shootAction()
    {

        if (CanShoot()) //Input.GetKeyDown(KeyCode.Mouse1) 
        {
            shoot();
        }

    }

    private void shoot()
    {
        nextShootTime = Time.time + 1 / fireRate;
        Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        
    }

    bool CanShoot()
    {
       System.Random randomNumber = new System.Random();
        int num = randomNumber.Next(0, NumberOfEnemes);
        return
            Time.time >= nextShootTime 
            && Enemy[num].GetDistanceToTarget() <= StartShootDistance 
            && isActive
            && !isWalking
            && !isListEmpty;
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

