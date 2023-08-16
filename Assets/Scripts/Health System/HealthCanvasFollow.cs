using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCanvasFollow : MonoBehaviour
{

    [SerializeField] private Transform player;
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
        
        Vector3 desiredPos = new Vector3(player.position.x, player.position.y + YDistance, player.position.z + ZDistance);

        HealthCanvasTransform.position = desiredPos;

    }
}
