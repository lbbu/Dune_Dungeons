using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowPlayer : MonoBehaviour, IEnemy
{
    [SerializeField]  Transform player;
    [SerializeField] float range = 14f;
    [SerializeField] float stopChasTargetRange = 5f;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    NavMeshAgent agent;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        distanceToTarget = Vector3.Distance(player.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }else if( distanceToTarget<=range)
        {
            isProvoked = true;
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
            isProvoked=false;
        }
    }
    void faceTarget()
    {
        if (distanceToTarget <= range / 2)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 6);
        }
    }

    public float DistanceToTarget()
    {
        return distanceToTarget;
    }
}
