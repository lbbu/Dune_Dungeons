using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCanvasFollow : MonoBehaviour
{

    [SerializeField] private Transform objectToFollow;
    private RectTransform HealthCanvasTransform;

    private void Awake()
    {
        HealthCanvasTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float YDistance = 2.5f;
        float ZDistance = 1f;
        
        Vector3 desiredPos = new Vector3(objectToFollow.position.x, objectToFollow.position.y + YDistance, objectToFollow.position.z + ZDistance);

        HealthCanvasTransform.position = desiredPos;

    }
}
