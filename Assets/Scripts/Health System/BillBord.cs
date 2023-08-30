using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBord : MonoBehaviour
{

    //this code makes the health bar looks at the camera

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + mainCamera.transform.forward);
    }
}
