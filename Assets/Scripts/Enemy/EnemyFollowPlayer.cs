using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowPlayer : Enemy
{
    [SerializeField] Transform target;
    [SerializeField] float range = 8f;
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
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }else if( distanceToTarget<=range)
        {
            isProvoked = true;
        }
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
        agent.SetDestination(target.position); 
    }
    void faceTarget()
    {
        if (distanceToTarget <= range / 2)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 6);
        }
    }
}
