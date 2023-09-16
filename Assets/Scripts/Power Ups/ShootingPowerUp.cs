using System.Collections;
using System.Collections.Generic;
using System.Windows;
using UnityEngine;

public class ShootingPowerUp : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerWeapon.ShootingEvent += HandleShootEvent;
    }

    private void OnDisable()
    {
        PlayerWeapon.ShootingEvent -= HandleShootEvent;
    }

    private void HandleShootEvent()
    {
        Debug.Log("Shoot Event");
        
    }
}
