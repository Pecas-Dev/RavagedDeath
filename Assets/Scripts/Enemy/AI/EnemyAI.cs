using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform playerTarget;
    [SerializeField] float chaseRange = 5f;


    NavMeshAgent navMeshAgentEnemy;
    float distnaceToTarget = Mathf.Infinity;


    bool isProvked = false;


    void Start()
    {
        navMeshAgentEnemy = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distnaceToTarget = Vector3.Distance(playerTarget.position, transform.position);

        if (isProvked)
        {
            EngageTarget();
        }
        else if (distnaceToTarget <= chaseRange)
        {
            isProvked = true;
        }


    }

    void EngageTarget()
    {
        if (distnaceToTarget >= navMeshAgentEnemy.stoppingDistance)
        {
            ChaseTarget();
        }
        if (distnaceToTarget <= navMeshAgentEnemy.stoppingDistance)
        {
            AttackTarget();
        }
    }

    void ChaseTarget()
    {
        navMeshAgentEnemy.SetDestination(playerTarget.position);

    }

    void AttackTarget()
    {
        Debug.Log(name + " has attacked " + playerTarget.name);
    }



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
