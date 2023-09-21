using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSystem : MonoBehaviour
{
   [SerializeField] PlayerInventory playerInventory;

    [SerializeField]  string[] DoorKey = { "Gold", "Silver" };
    [SerializeField] int AmountOfKeys;

    //num 1 = gold // num 2 = silver
    int TypeOfKeyToDecrease= 0;
    
    private void Start()
    {

    }
    private void Update()
    {
        //if(TypeOfKeyToDecrease == 1)
        //{
        //    playerInventory.DecreaseGoldKeyNum(AmountOfKeys);
        //    TypeOfKeyToDecrease = 0;


        //}else if (TypeOfKeyToDecrease == 2)
        //{
        //    playerInventory.DecreaseSetSilverKeyNum(AmountOfKeys);
        //    TypeOfKeyToDecrease = 0;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {

        
            if (DoorKey[0]=="Gold" && playerInventory.GetGoldKeyNum() >=1)
            {
                playerInventory.DecreaseGoldKeyNum(AmountOfKeys);
                TypeOfKeyToDecrease = 1;
                GetComponent<Animator>().SetTrigger("open");
                Debug.Log("OnTriggerEnter!!! GOLD");
            }
            else if (DoorKey[0]== "Silver" && playerInventory.GetSilverKeyNum() >= 1)
            {
               playerInventory.DecreaseSetSilverKeyNum(AmountOfKeys);
                TypeOfKeyToDecrease = 2;
                GetComponent<Animator>().SetTrigger("open");
                Debug.Log("OnTriggerEnter!!! SILVER");

            }
        }
    
}
