using UnityEngine;


public class CameraFollower : MonoBehaviour
{
    // first approach
    public Transform target; // The player's transform
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    //   public Vector2 minBounds; // Minimum camera position  minX=-68.424 & Y-Left=92.29285
    //  public Vector2 maxBounds; // Maximum camera position  maxX=-94.91066  &Y-Right=92.2928

    void LateUpdate()
    {
        // Calculate the desired position of the camera based on the player's position
        Vector3 desiredPosition = target.position + offset;

        // Limit the camera's position to the defined bounds
        // desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
        // desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);

        // Smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
    //************************************************************************************************************
    /* 
                     Second approach

    /* [SerializeField]
     GameObject player;
     public float distance= -27.8f;
     void Update()
     {
         Vector3 back = -player.transform.forward;
         back.y = 0.47f; // this determines how high. Increase for higher view angle.
         transform.position = player.transform.position - back * distance;

         transform.forward = player.transform.position - transform.position;
     }*/
    //****************************************************************************************************************
    /*
     *          3rd approach
     *          
    public Vector3 targetPosition; // The position to follow.
    public float followSpeed = 5f; // Adjust the speed of camera following.

    private void Update()
    {
        // Calculate the target position along the Y-axis.
        Vector3 newPosition = new Vector3(transform.position.x, targetPosition.y, transform.position.z);

        // Smoothly move the camera towards the target position.
        transform.position = Vector3.Lerp(transform.position, newPosition, followSpeed * Time.deltaTime);
    }*/
    /*********************************************************************/
    /* 4th approach
    
    public float moveSpeed = 5f;
    public float minY; 
    public float maxY ; 

    void Update()
    {
        float inputY = Input.GetAxis("Vertical"); 

        float newPositionY = transform.position.y + inputY * moveSpeed * Time.deltaTime;

        newPositionY = Mathf.Clamp(newPositionY, minY, maxY);

        transform.position = new Vector3(transform.position.x, newPositionY, transform.position.z);
    }*/

}
