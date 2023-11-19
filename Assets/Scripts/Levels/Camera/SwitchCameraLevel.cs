using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameraLevel : MonoBehaviour
{
     [SerializeField] private Player player;
   

    [SerializeField] int NumberOfRooms;
    [SerializeField] CinemachineVirtualCamera[] CurrentCM;
    int Current_CM_Index = 0;
    int Pre_CM_Index = 0;

    [SerializeField] private Transform cameraToFollow;//by Zaid.

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
        
        CamFollow();
    }

    public void CamFollow()
    {
        Vector3 TargetPos =
         new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, TargetPos, 1);
    }




    private void changeCamByOrder()
    {
        try
        {

            CurrentCM[Pre_CM_Index].gameObject.SetActive(false);
            CurrentCM[Current_CM_Index].gameObject.SetActive(true);
        }
        catch
        {

        }
    }
}
