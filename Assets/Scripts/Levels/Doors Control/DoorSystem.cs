using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSystem : MonoBehaviour
{
    [SerializeField] PlayerInventory playerInventory;

    [SerializeField] string[] DoorKey = { "Gold", "Silver" };
    [SerializeField] int AmountOfKeys;

    bool IsDoorOpend = false;
    //num 1 = gold // num 2 = silver
    int TypeOfKeyToDecrease = 0;

    bool isOpining = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!IsDoorOpend && other.CompareTag("Player"))
        {


            if (DoorKey[0] == "Gold" && playerInventory.GetGoldKeyNum() >= AmountOfKeys)
            {
                playerInventory.DecreaseGoldKeyNum(AmountOfKeys);
                TypeOfKeyToDecrease = 1;
                GetComponent<Animator>().SetTrigger("open");
                IsDoorOpend = true;
            }
            else if (DoorKey[0] == "Silver" && playerInventory.GetSilverKeyNum() >= AmountOfKeys)
            {
                playerInventory.DecreaseSetSilverKeyNum(AmountOfKeys);
                TypeOfKeyToDecrease = 2;
                GetComponent<Animator>().SetTrigger("open");
                IsDoorOpend = true;
            }


            
        }
        else if (IsDoorOpend && other.CompareTag("Player"))
        {
            GetComponent<Animator>().SetTrigger("open");
        }
    }
}
