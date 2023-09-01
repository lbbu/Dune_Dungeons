using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFindPathM7MD : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] Player player;
    [SerializeField] EnemiesMovments movements;
    [SerializeField] Animator animator;

    [Header("Information")]
    [SerializeField] private float enemyRotationSpeed = 15f;
    [SerializeField] private float attackRange = 2f;

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

        if(!movements)
            movements = GetComponent<MeleEnemyMovements>();

        if(!animator)
            animator = GetComponent<Animator>();
        
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

        if (Vector3.Distance(transform.position, player.transform.position) > attackRange)
        {

            animator.SetBool(IDLE_ANIMATION, false);
            animator.SetBool(IS_MOVING_ANIMATION, true);
            animator.SetBool(IS_ATTACKING_ANIMATION, false);

            state = State.ChaseTarget;

        }
        else
        {

            animator.SetBool(IDLE_ANIMATION, false);
            animator.SetBool(IS_MOVING_ANIMATION, false);
            animator.SetBool(IS_ATTACKING_ANIMATION, true);

        }

    }

    private void ChasePlayer()
    {

        float xVector = player.transform.position.x - transform.position.x;
        float zVector = player.transform.position.z - transform.position.z;

        Vector2 inputVector = new Vector2(xVector, zVector).normalized;

        //move towards your forward
        movements.HandleMovements(inputVector);

        if(Vector3.Distance(transform.position, player.transform.position) <= attackRange / 1.25)
        {
            state = State.AttackTarget;
            animator.SetBool(IS_MOVING_ANIMATION, false);
            animator.SetBool(IS_ATTACKING_ANIMATION, true);
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
        if(Vector3.Distance(transform.position, player.transform.position) > attackRange * 1.2f)
        {

            animator.SetBool(IS_MOVING_ANIMATION, true);
            animator.SetBool(IS_ATTACKING_ANIMATION, false);

            state = State.ChaseTarget;

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}