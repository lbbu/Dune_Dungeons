using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowPlayer : MonoBehaviour, IEnemy
{
    [SerializeField] string playerTag = "Player"; // The tag of the player GameObject

    [SerializeField] float sightRange = 14f;
    [SerializeField] float stopChaseTargetRange = 5f;

    float distanceToTarget = Mathf.Infinity;
    bool isFollowing = false;
    NavMeshAgent agent;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);

        if (playerObject == null)
        {
            isFollowing = false;
            return;
        }

        distanceToTarget = Vector3.Distance(playerObject.transform.position, transform.position);

        if (distanceToTarget <= sightRange)
        {
            isFollowing = true;
        }
        else
        {
            isFollowing = false;
        }

        if (isFollowing)
        {
            EngageTarget();
        }

        stopChaseTarget();
    }

    private void EngageTarget()
    {
        faceTarget();
        if (distanceToTarget >= agent.stoppingDistance)
        {
            chaseTarget();
        }
    }

    void chaseTarget()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObject != null)
        {
            agent.SetDestination(playerObject.transform.position);
        }
    }

    void stopChaseTarget()
    {
        if (distanceToTarget >= stopChaseTargetRange)
        {
            isFollowing = false;
        }
    }

    void faceTarget()
    {
        if (distanceToTarget <= sightRange / 2)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);
            if (playerObject != null)
            {
                Vector3 direction = (playerObject.transform.position - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 6);
            }
        }
    }

    public float GetDistanceToTarget()
    {
        return distanceToTarget;
    }
}
