using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowPlayer : MonoBehaviour, IEnemy
{
    [SerializeField]  Transform player;

    [SerializeField] float sightRange = 14f;

    [SerializeField] float stopChasTargetRange = 5f;
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
        distanceToTarget = Vector3.Distance(player.position, transform.position);
        if (isFollowing)
        {
            EngageTarget();
        }else if( distanceToTarget<=sightRange)
        {
            isFollowing = true;
        }
        stopChasTarget();
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
        agent.SetDestination(player.position); 
    }

    void stopChasTarget()
    {
        if(distanceToTarget >= stopChasTargetRange)
        {
            isFollowing=false;
        }
    }
    void faceTarget()
    {
        if (distanceToTarget <= sightRange / 2)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 6);
        }
    }

    public float GetDistanceToTarget()
    {
        return distanceToTarget;
    }
}
