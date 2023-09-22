using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFindPathM7MD : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] Player player;
    [SerializeField] Animator animator;
    [SerializeField] NavMeshAgent enemyNavMeshAgent;

    [Header("Information")]
    [SerializeField] private float enemyRotationSpeed = 10f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private LayerMask whatIsGround, whatIsPlayer;

    private bool playerInSightRange, playerInAttackRange;

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

        if(!animator)
            animator = FindObjectOfType<EnemyAttackM7MD>().GetComponent<Animator>();

        if(!enemyNavMeshAgent)
            enemyNavMeshAgent = GetComponent<NavMeshAgent>();
        
    }

    // Start is called before the first frame update
    void Start()
    {

        state = State.Idle;
        animator.SetBool(IDLE_ANIMATION, true);

    }

    // Update is called once per frame
    void Update()
    {

        switch(state)
        {
            case State.Idle:

                Idle();

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

    private void Idle()
    {

        //wait for 1 sec then



        state = State.ChaseTarget;
        //go from idle animation to run animation
        animator.SetBool(IDLE_ANIMATION, false);
        animator.SetBool(IS_MOVING_ANIMATION, true);



    }

    private void ChasePlayer()
    {


        enemyNavMeshAgent.SetDestination(player.transform.position);

        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange / 1.5f, whatIsPlayer);
        
        if (playerInAttackRange)
        {
            state = State.AttackTarget;
            //go from run animation to attack animation
            animator.SetBool(IS_MOVING_ANIMATION, false);
            animator.SetBool(IS_ATTACKING_ANIMATION, true);
        }
        
    }

    void FaceTarget()
    {        
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        Quaternion test = Quaternion.Slerp(transform.rotation, lookRotation, enemyRotationSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Slerp(transform.rotation, test, enemyRotationSpeed * Time.deltaTime);

    }

    private void AttackPlayer()
    {

        enemyNavMeshAgent.SetDestination(transform.position);
        FaceTarget();

        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange * 1.1f, whatIsPlayer);

        if (!playerInAttackRange)
        {

            state = State.ChaseTarget;
            //go from attack animation to run animation
            animator.SetBool(IS_MOVING_ANIMATION, true);
            animator.SetBool(IS_ATTACKING_ANIMATION, false);




        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}