using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] int AmmoInventory = 50;



    public int BulletInventory()
    {
        return AmmoInventory;
    }
    public void EditBulletInventory(int usedAmmo)
    {
        AmmoInventory-= usedAmmo;
    }
}
