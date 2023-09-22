using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameraLevel : MonoBehaviour
{
    [SerializeField]  Player player;
    [SerializeField] int NumberOfRooms;
    [SerializeField] CinemachineVirtualCamera[] CurrentCM;
    int Current_CM_Index = 0;
    int Pre_CM_Index = 0;

    private void Start()
    {
        CurrentCM[Current_CM_Index].gameObject.SetActive(true);
    }
    private void Update()
    {
        Pre_CM_Index = Current_CM_Index;
        Current_CM_Index = player.GetDetectdRoomNumber()-1;
        if(Current_CM_Index != Pre_CM_Index)
        {
            Debug.Log("Pre " + Pre_CM_Index + "  post " + Current_CM_Index);
           changeCamByOrder();
        }
        
    }

   

    private void changeCamByOrder()
    { 
      
       
         CurrentCM[Pre_CM_Index].gameObject.SetActive(false);
        CurrentCM[Current_CM_Index].gameObject.SetActive(true);
    }
}
