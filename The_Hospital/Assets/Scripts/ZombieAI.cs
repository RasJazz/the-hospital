using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ZombieAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    private AudioSource audioSource;

    public float visionRadius = 10000f;
    public float attackRange = 2f;

    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (!agent)
        {
            Debug.LogError("NavMeshAgent is missing on the zombie!");
        }

        animator = GetComponent<Animator>();
        if (!animator)
        {
            Debug.LogError("Animator component is missing!");
        }

        audioSource = GetComponent<AudioSource>();
        if (!audioSource)
        {
            Debug.LogError("AudioSource component is missing!");
        }

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj)
        {
            player = playerObj.transform;
            Debug.Log("Player found and assigned.");
        }
        else
        {
            Debug.LogError("No GameObject with the 'Player' tag found in the scene!");
        }
    }

    void Update()
    {
        if (!player || !agent)
        {
            Debug.LogError("Player or NavMeshAgent is missing!");
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Debug.Log($"Distance to Player: {distanceToPlayer}");

        if (distanceToPlayer <= visionRadius && distanceToPlayer > attackRange)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsRunningInPlace", false);

            if (!audioSource.isPlaying)
            {
                audioSource.loop = true; // Ensure looping is enabled
                audioSource.Play();
                Debug.Log("Zombie sound is playing.");
            }

            Debug.Log("Zombie is moving toward the player.");
        }
        else if (distanceToPlayer <= attackRange + 0.1f) // Add margin for error
        {
            Debug.Log("Zombie has reached the player!");
            RestartGame();
        }
        else
        {
            agent.isStopped = true;
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunningInPlace", false);

            if (audioSource.isPlaying)
            {
                audioSource.Stop();
                Debug.Log("Zombie sound stopped.");
            }

            Debug.Log("Zombie is idle.");
        }
    }

    void RestartGame()
    {
        Debug.Log("RestartGame method called.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Zombie caught the player!");
            RestartGame();
        }
    }
}
