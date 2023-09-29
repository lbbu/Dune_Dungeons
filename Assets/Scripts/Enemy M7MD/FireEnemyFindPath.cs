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

    //Patroling
    private float walkPointRange;
    private bool walkPointSet;
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
        
        switch(state)
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
        }

    }




    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(playerHealth.transform.position);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
            /*
            state = State.AttackTarget;
            ActivateAnimation(IS_ATTACKING_ANIMATION);
            */
        }

    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, 0f, transform.position.z + randomZ);

        RaycastHit[] objectsBelow = Physics.RaycastAll(walkPoint, -Vector3.up, 2f, whatIsGround);

        bool obstacleTest = true;

        foreach(RaycastHit objectBelow in objectsBelow)
        {
            if(objectBelow.collider.gameObject.layer == whatIsObstacle)
            {
                obstacleTest = false;
            }
        }

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround) && obstacleTest)
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
    }

}
