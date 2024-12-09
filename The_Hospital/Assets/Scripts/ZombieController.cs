using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private Transform target; // The player or target to follow
    public float attackRange = 2.0f; // Attack range

    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform; // Ensure the player has the "Player" tag

        // Match NavMeshAgent speed with walking animation speed
        navMeshAgent.speed = 2.0f; // Set this to match your zombie's walking speed
    }

    void Update()
{
    float distance = Vector3.Distance(transform.position, target.position);

    if (distance > attackRange)
    {
        animator.SetBool("IsWalking", true);
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(target.position);

        // Adjust walking animation speed based on NavMeshAgent velocity
        animator.SetFloat("WalkSpeed", navMeshAgent.velocity.magnitude / navMeshAgent.speed);
    }
    else
    {
        animator.SetBool("IsWalking", false);
        navMeshAgent.isStopped = true;
        animator.SetTrigger("AttackTrigger");
    }
}
}
