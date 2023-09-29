using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class FireEnemyFindPath : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private LayerMask whatIsGround, whatIsObstacle;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private PlayerHealth playerHealth;

    [SerializeField] private float timeBetweenAttacks = 2f;
    private float currentTime = 0;
    [SerializeField] private float enemyRotationSpeed = 10f;
    private bool allowToRotate;

    //Patroling
    [SerializeField] private float walkPointRange;
    bool walkPointSet;
    [SerializeField] private Vector3 walkPoint;

    const string IS_MOVING_ANIMATION = "isMoving";
    const string IS_ATTACKING_ANIMATION = "isAttacking";
    const string IDLE_ANIMATION = "Idle";

    [SerializeField] private State state;

    //State
    private enum State
    {
        Patroling,
        AttackTarget,
        Idle,
    }

    private void Awake()
    {
        if(!animator)
            animator = GetComponent<Animator>();
        if(!agent)
            agent = GetComponent<NavMeshAgent>();
        if(!playerHealth)
            playerHealth = FindObjectOfType<PlayerHealth>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        state = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {

        if(allowToRotate)
        {
            FaceTarget();
        }

        switch (state)
        {
            case State.Idle:
                Idle();

                break;

            case State.Patroling:
                Patroling();

                break;

            case State.AttackTarget:

                break;

            default: 

                break;
        }

    }

    private void Idle()
    {

        currentTime += Time.deltaTime;

        if(currentTime >= 1)
        {
            state = State.Patroling;
            ActivateAnimation(IS_MOVING_ANIMATION);
            currentTime = 0;
        }

    }




    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        currentTime += Time.deltaTime;
        if(currentTime >= 2)
        {
            walkPointSet = false;

            state = State.AttackTarget;
            ActivateAnimation(IS_ATTACKING_ANIMATION);
            currentTime = 0;
        }

        //Walkpoint reached
        if (Vector3.Distance(transform.position, walkPoint) <= 0.1f)
        {
            walkPointSet = false;
            
            state = State.AttackTarget;
            ActivateAnimation(IS_ATTACKING_ANIMATION);
            currentTime = 0;
        }

    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, 0f, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ActivateAnimation(string animationName)
    {
        animator.SetBool(IDLE_ANIMATION, false);
        animator.SetBool(IS_MOVING_ANIMATION, false);
        animator.SetBool(IS_ATTACKING_ANIMATION, false);

        animator.SetBool(animationName, true);
    }

    public void EndAttack()
    {
        currentTime = 0;

        state = State.Idle;
        ActivateAnimation(IDLE_ANIMATION);

        allowToRotate = false;
    }

    public void StartAttack()
    {
        allowToRotate = true;
    }

    void FaceTarget()
    {
        Vector3 direction = (playerHealth.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        Quaternion test = Quaternion.Slerp(transform.rotation, lookRotation, enemyRotationSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Slerp(transform.rotation, test, enemyRotationSpeed * Time.deltaTime);

    }

}
