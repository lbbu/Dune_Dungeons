using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    [SerializeField] float fireRate = 1f;
    //[SerializeField] float StartShootDistance = 10f;
    //[SerializeField] int NumberOfEnemes = 0;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootPoint;
    [SerializeField] PlayerMovements PlayerMovement ;
    [SerializeField] FacingEnemy facingEnemy;
    float nextShootTime;
    bool isActive= false;
    bool isWalking = false;
    bool isListEmpty = false;


    Transform closestEnemy;
    List<Transform> nearbyEnemies = new List<Transform>();
    [SerializeField] GameObject AllEnemys;
    float detectionRange = 10f;
    [SerializeField] float sightRange = 14f;

    private void Start()
    {
        
    }

    void Update()
    {
        UpdateNearbyEnemies();
       isListEmpty = facingEnemy.GetIsEmptyListOfEnemys();
        isWalking = PlayerMovement.IsWalking();
        shootAction();
    }

    private void shootAction()
    {

        if (CanShoot())
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
       
        return
            Time.time >= nextShootTime 
            && isActive
            && !isWalking
            && !isListEmpty
            && closestEnemy != null;
    }

    void UpdateNearbyEnemies()
    {
        nearbyEnemies.Clear();

        foreach (Transform enemy in AllEnemys.transform)
        {
            float distance = Vector3.Distance(enemy.position, transform.position);
            if (distance <= detectionRange)
            {
                nearbyEnemies.Add(enemy);
            }
        }

        FindClosestEnemy();
    }

    void FindClosestEnemy()
    {
        float closestDistance = Mathf.Infinity;
        closestEnemy = null;

        foreach (Transform enemy in AllEnemys.transform)
        {
            float distance = Vector3.Distance(enemy.position, transform.position);
            if (distance < closestDistance && distance <= sightRange)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }
    }

    public bool GetIsEmptyListOfEnemys()
    {
        if (nearbyEnemies.Count == 0)
            return true;
        return false;
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

