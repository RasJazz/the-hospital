using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ZombieAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    private AudioSource audioSource;

    public AudioClip alertSoundClip; // Sound to play when the zombie first sees the player
    public Transform[] patrolPoints; // Waypoints for patrol
    public Transform doorPatrolPoint; // Patrol point near the door
    public DoorController doorController; // Reference to the door's state
    public float visionRadius = 10000f;
    public float attackRange = 2f;
    public float idleTime = 2f; // Time to wait at each patrol point

    private Animator animator;
    private bool hasSeenPlayer = false;
    private int currentPatrolIndex = 0;
    private bool isWaiting = false;
    private float waitTimer = 0f;

    private float soundTimer = 0f; // Timer to track sound cooldown
    private float soundCooldown = 5f; // Cooldown time between sound plays

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

        if (patrolPoints.Length > 0)
        {
            GoToNextPatrolPoint();
        }
        else
        {
            Debug.LogError("No patrol points assigned!");
        }
    }

    void Update()
    {
        if (!player || !agent)
        {
            Debug.LogError("Player or NavMeshAgent is missing!");
            return;
        }

        soundTimer += Time.deltaTime; // Increment sound timer

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= visionRadius)
        {
            // Chase player
            ChasePlayer(distanceToPlayer);
        }
        else
        {
            // Patrol when the player is not visible
            Patrol();
        }
    }

    void ChasePlayer(float distanceToPlayer)
    {
        hasSeenPlayer = true;

        if (distanceToPlayer <= visionRadius && distanceToPlayer > attackRange)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
            animator.SetBool("IsWalking", true);

            // Play sound only if the cooldown has elapsed
            if (soundTimer >= soundCooldown)
            {
                audioSource.loop = false;
                audioSource.Play();
                soundTimer = 0f; // Reset the timer
            }
        }
        else if (distanceToPlayer <= attackRange)
        {
            RestartGame();
        }
    }

    void Patrol()
    {
        if (agent.remainingDistance < 0.5f && !isWaiting)
        {
            isWaiting = true;
            waitTimer = idleTime;
            animator.SetBool("IsWalking", false);
        }

        if (isWaiting)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0f)
            {
                isWaiting = false;
                GoToNextPatrolPoint();
            }
        }

        if (!agent.pathPending && !isWaiting)
        {
            animator.SetBool("IsWalking", true);

            // Play sound only if the cooldown has elapsed
            if (!audioSource.isPlaying && soundTimer >= soundCooldown)
            {
                audioSource.loop = false;
                audioSource.Play();
                soundTimer = 0f; // Reset the timer
            }
        }
        else if (isWaiting && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    void GoToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0)
            return;

        Transform nextPatrolPoint = patrolPoints[currentPatrolIndex];

        // Check if the patrol point is near a door and if the door is open
        if (nextPatrolPoint == doorPatrolPoint && doorController != null)
        {
            if (!doorController.isOpen)
            {
                Debug.Log("Door is closed. Waiting for it to open...");
                return; // Wait for the door to open
            }
        }

        // Set the destination to the next patrol point
        agent.destination = nextPatrolPoint.position;
        animator.SetBool("IsWalking", true);

        // Update patrol index for the next point
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RestartGame();
        }
    }
}
