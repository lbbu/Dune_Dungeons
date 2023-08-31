using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMovments : MonoBehaviour
{


    //fields Values
    [SerializeField] protected float moveSpeed = 7f;
    [SerializeField] protected float RotationSpeed = 15f;
    [SerializeField] protected float enemyRadius = 0.7f;
    [SerializeField] protected float enemyHeight = 1f;
    [SerializeField] protected LayerMask obstacleLayer;
    protected bool isWalking;


    //return True if the player is walking
    public bool IsWalking() => isWalking;


    public void HandleMovements(Vector2 inputVector)
    {

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        isWalking = moveDir != Vector3.zero;

        float moveDistance = moveSpeed * Time.deltaTime;

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position +
            Vector3.up * enemyHeight, enemyRadius, moveDir, moveDistance, obstacleLayer);


        if (!canMove)
        {

            //cannot move towards moveDir direction


            // Attempt only X movements
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position +
                Vector3.up * enemyHeight, enemyRadius, moveDirX, moveDistance, obstacleLayer);

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

                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * enemyHeight,
                    enemyRadius, moveDirZ, moveDistance, obstacleLayer);

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
