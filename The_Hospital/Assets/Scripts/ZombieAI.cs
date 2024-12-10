using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ZombieAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public float visionRadius = 10f;
    public float attackRange = 2f;

    private Animator animator;
    private bool isAttacking = false; // Flag to prevent repeated attacks

    void Start()
    {
        animator = GetComponent<Animator>();
        if (!agent)
            agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the zombie can see the player
        if (distanceToPlayer <= visionRadius && !isAttacking)
        {
            agent.isStopped = false; // Ensure the agent can move
            agent.SetDestination(player.position);
            animator.SetBool("IsWalking", true);

            // Check if the zombie is close enough to attack
            if (distanceToPlayer <= attackRange)
            {
                StartAttack();
            }
        }
        else
        {
            StopMovement();
        }
    }

    void StartAttack()
    {
        isAttacking = true; // Prevent further movement or attacking
        animator.SetBool("IsWalking", false);
        animator.SetTrigger("Attack");
        agent.isStopped = true; // Stop the agent while attacking

        // Add a small delay before resetting attack (adjust based on animation length)
        Invoke(nameof(ResetAttack), 1.5f);
    }

    void ResetAttack()
    {
        isAttacking = false;
    }

    void StopMovement()
    {
        agent.isStopped = true;
        animator.SetBool("IsWalking", false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("You Died!");
            Invoke("RestartGame", 2f); // Delay the restart for dramatic effect
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
