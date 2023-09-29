using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemyBullets : MonoBehaviour
{
    public float speed = 5f; // The speed of the bullet
    public float maxHeight = 5f; // The maximum height the bullet reaches
    private Vector3 targetPosition; // The final destination of the bullet

    private Vector3 initialPosition;
    private float startTime;

    private bool isMoving = true;
    private bool canMove = false;

    private PlayerHealth playerHealth;

    private void Awake()
    {
        canMove = false;
    }

    void Start()
    {
        initialPosition = transform.position;
        startTime = Time.time;
    }

    void Update()
    {
        BulletMove();
    }

    public void SetTargetPos(Vector3 targetPos)
    {
        targetPosition = targetPos;
        canMove = true;
    }

    private void BulletMove()
    {

        if (!canMove)
            return;

        if (isMoving)
        {
            float journeyLength = Vector3.Distance(initialPosition, targetPosition);
            float journeyTime = journeyLength / speed;

            float elapsedTime = Time.time - startTime;
            float journeyProgress = elapsedTime / journeyTime;

            if (journeyProgress >= 1f)
            {
                // If the journey is complete, stop moving and perform explosion logic here
                isMoving = false;
                Explode();
            }
            else
            {
                // Calculate the position of the bullet along the curved path
                float yOffset = Mathf.Sin(journeyProgress * Mathf.PI) * maxHeight;
                transform.position = Vector3.Lerp(initialPosition, targetPosition, journeyProgress);
                transform.position += Vector3.up * yOffset;
            }
        }
    }

    void Explode()
    {
        MakaDamage();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerHealth>())
            playerHealth = other.gameObject.GetComponent<PlayerHealth>();



    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.GetComponent<PlayerHealth>())
            playerHealth = null;

    }


    public void MakaDamage()
    {

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(20);
        }
    }

}
