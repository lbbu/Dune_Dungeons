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

        state = State.ChaseTarget;
        animator.SetBool(IS_MOVING_ANIMATION, true);

    }

    // Update is called once per frame
    void Update()
    {

        switch(state)
        {
            case State.ChaseTarget:

                ChasePlayer();

                break; 

            case State.AttackTarget:

                AttackPlayer();

                break;

            case State.Idle:



                break;

            default: 

                break;
        }

    }

    private void ChasePlayer()
    {

        FaceTarget();

        //move towards your forward
        movements.HandleMovements(transform.forward.normalized);

        if(Vector3.Distance(transform.position, player.transform.position) <= attackRange / 2)
        {
            state = State.AttackTarget;
            animator.SetBool(IS_MOVING_ANIMATION, false);
            animator.SetBool(IS_ATTACKING_ANIMATION, true);
        }

    }

    void FaceTarget()
    {

        enemyRotationSpeed += Time.deltaTime;
        
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, enemyRotationSpeed);
        
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