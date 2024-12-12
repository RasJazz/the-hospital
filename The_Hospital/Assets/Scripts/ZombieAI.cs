using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ZombieAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    private AudioSource audioSource;

    public AudioClip alertSoundClip; // Sound to play when the zombie first sees the player
    public AudioClip chaseSoundClip; // Sound to play while chasing
    public Transform[] patrolPoints; // Waypoints for patrol
    public Transform doorPatrolPoint; // Patrol point near the door
    public DoorController doorController; // Reference to the door's state
    public float visionRadius = 20f; // Range within which the zombie can see the player
    public float attackRange = 2f; // Range within which the zombie attacks the player
    public float idleTime = 2f; // Time to wait at each patrol point
    public float alertSoundCooldown = 5f; // Delay before the alert sound can replay

    [Range(0f, 1f)] public float alertVolume = 0.5f; // Volume for the alert sound
    [Range(0f, 1f)] public float chaseVolume = 0.3f; // Volume for the chase sound

    private Animator animator;
    private bool hasSeenPlayer = false;
    private int currentPatrolIndex = 0;
    private bool isWaiting = false;
    private float waitTimer = 0f;
    private float lastAlertSoundTime = -Mathf.Infinity; // Tracks when the alert sound was last played

    void Start()
    {
        // Initialize components
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        if (!agent) Debug.LogError("NavMeshAgent is missing on the zombie!");
        if (!animator) Debug.LogError("Animator component is missing!");
        if (!audioSource) Debug.LogError("AudioSource component is missing!");

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

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= visionRadius)
        {
            // Play alert sound if zombie just saw the player and the cooldown has passed
            if (!hasSeenPlayer && Time.time > lastAlertSoundTime + alertSoundCooldown)
            {
                PlayAlertSound();
                hasSeenPlayer = true;
            }

            // Chase the player
            ChasePlayer(distanceToPlayer);
        }
        else
        {
            // Reset hasSeenPlayer if the player is no longer visible
            hasSeenPlayer = false;

            // Patrol when the player is not visible
            Patrol();
        }
    }

    void PlayAlertSound()
    {
        if (audioSource && alertSoundClip)
        {
            audioSource.volume = alertVolume; // Set the volume for the alert sound
            audioSource.PlayOneShot(alertSoundClip); // Play the alert sound once
            lastAlertSoundTime = Time.time; // Update the time the sound was played
            Debug.Log("Alert sound played!");
        }
    }

    void ChasePlayer(float distanceToPlayer)
    {
        if (distanceToPlayer > attackRange)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position); // Move toward the player
            animator.SetBool("IsWalking", true);

            // Play chase sound if not already playing
            if (audioSource.clip != chaseSoundClip || !audioSource.isPlaying)
            {
                audioSource.clip = chaseSoundClip;
                audioSource.volume = chaseVolume; // Set the volume for the chase sound
                audioSource.loop = true;
                audioSource.Play();
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
            audioSource.Stop(); // Stop all sounds while patrolling
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
        Debug.Log("Restarting Game...");
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
