using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerMovements : MonoBehaviour
{
    //fields Values
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float RotationSpeed = 15f;
    [SerializeField] private float playerRadius = 0.7f;
    [SerializeField] private float playerHeight = 1f;
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private Transform bottomPoint; //by M7MD
    private bool isWalking;

    [SerializeField] public float minX, maxX; //by zaid


    //return True if the player is walking
    public bool IsWalking() => isWalking;

   

    // Update is called once per frame
    void Update()
    {
        /*
        float inputX = Input.GetAxis("Horizontal");
        float newPosition = transform.position.x + inputX * moveSpeed * Time.deltaTime;
        newPosition = Mathf.Clamp(newPosition, minX, maxX);
        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
       ==> These lines constrains the player's movement on the X-axis between the minX and maxX limits 
        */

        // HandleMovements();


        // Debug.Log(gameInput.GetInputVectorNormalized());

    }



    public void HandleMovements(Vector2 inputVector)
    {
        //get the input vector from the GameInput Class
        //Vector2 inputVector = gameInput.GetInputVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        isWalking = moveDir != Vector3.zero;

        float moveDistance = moveSpeed * Time.deltaTime;

        bool canMove = !Physics.CapsuleCast(bottomPoint.position, transform.position + 
            Vector3.up * playerHeight, playerRadius, moveDir, moveDistance, obstacleLayer);


        if (!canMove)
        {

            //cannot move towards moveDir direction


            // Attempt only X movements
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(bottomPoint.position, transform.position + 
                Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance, obstacleLayer);

            if (canMove)
            {
                //can move only on the X
                moveDir = moveDirX;
            }
            else
            {
                //cannot move only on the X

                //Attempts only Z movements
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;

                canMove = !Physics.CapsuleCast(bottomPoint.position, transform.position + Vector3.up * playerHeight, 
                    playerRadius, moveDirZ, moveDistance, obstacleLayer);

                if (canMove)
                {
                    //can move only on the Z
                    moveDir = moveDirZ;
                }
                else
                {
                    //cannot move in any direction
                }

            }
        }

        if (canMove)
        {
            transform.position += moveDir * moveDistance;
        }

        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * RotationSpeed);
    }



}
