using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFindPathM7MD : MonoBehaviour
{
    float distance;
    [Header("Objects")]
    [SerializeField] Player player;
    [SerializeField] Animator animator;
    [SerializeField] NavMeshAgent enemyNavMeshAgent;

    [Header("Information")]
    [SerializeField] private float enemyRotationSpeed = 10f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private LayerMask whatIsPlayer;

    [SerializeField] private float playerInSightRange;
    bool playerInAttackRange;

    const string IS_MOVING_ANIMATION = "isMoving";
    const string IS_ATTACKING_ANIMATION = "isAttacking";
    const string IDLE_ANIMATION = "Idle";

    private enum State
    {
        ChaseTarget,
        AttackTarget,
        Idle,
    }

    private State state;

    private void Awake()
    {
        if (!player)
            player = FindObjectOfType<Player>();

        if (!animator)
            animator = GetComponent<Animator>(); // Changed to get the animator from the current object.

        if (!enemyNavMeshAgent)
            enemyNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;
        SetAnimation(IDLE_ANIMATION);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);

        switch (state)
        {
            case State.Idle:
                if (distance < playerInSightRange)
                    SetState(State.ChaseTarget);
                break;

            case State.ChaseTarget:
                ChasePlayer();
                break;

            case State.AttackTarget:
                AttackPlayer();
                break;

            default:
                break;
        }
    }

    private void SetState(State newState)
    {
        if (state != newState)
        {
            state = newState;

            switch (state)
            {
                case State.Idle:
                    SetAnimation(IDLE_ANIMATION);
                    break;

                case State.ChaseTarget:
                    SetAnimation(IS_MOVING_ANIMATION);
                    break;

                case State.AttackTarget:
                    SetAnimation(IS_ATTACKING_ANIMATION);
                    break;
            }
        }
    }

    private void ChasePlayer()
    {
        enemyNavMeshAgent.SetDestination(player.transform.position);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange / 1.5f, whatIsPlayer);

        if (playerInAttackRange)
        {
            SetState(State.AttackTarget);
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, enemyRotationSpeed * Time.deltaTime);
    }

    private void AttackPlayer()
    {
        enemyNavMeshAgent.SetDestination(transform.position);
        FaceTarget();
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange * 1.1f, whatIsPlayer);

        if (!playerInAttackRange)
        {
            SetState(State.ChaseTarget);
        }
    }

    private void SetAnimation(string animationName)
    {
        animator.SetBool(IDLE_ANIMATION, animationName == IDLE_ANIMATION);
        animator.SetBool(IS_MOVING_ANIMATION, animationName == IS_MOVING_ANIMATION);
        animator.SetBool(IS_ATTACKING_ANIMATION, animationName == IS_ATTACKING_ANIMATION);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
