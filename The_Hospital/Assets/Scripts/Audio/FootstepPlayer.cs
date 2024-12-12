using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    private Player player;

    [SerializeField] private AudioClip[] footstepClips; // Array of footstep sounds
    [SerializeField] private float baseStepInterval = 0.5f; // Base time between footsteps
    [Range(0f, 1f)] [SerializeField] private float footstepVolume = 0.5f; // Volume of the footsteps

    private float stepInterval;
    private float stepTimer = 0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GetComponent<Player>();

        if (!audioSource)
            Debug.LogError("AudioSource component is missing!");

        if (!player)
            Debug.LogError("Player component is missing!");

        stepInterval = baseStepInterval; // Initialize with base interval
    }

    void Update()
    {
        if (IsPlayerMoving())
        {
            stepTimer += Time.deltaTime;

            if (stepTimer >= stepInterval)
            {
                PlayFootstepSound();
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = 0f; // Reset the timer when the player stops
        }
    }

    bool IsPlayerMoving()
    {
        // Assuming Player has a method to get input direction
        if (player == null) return false;

        Vector3 inputDirection = player.GetInputDirection(); // Adjust based on your Player script
        return inputDirection.sqrMagnitude > 0.01f; // Check if there's significant movement
    }

    void PlayFootstepSound()
    {
        if (footstepClips == null || footstepClips.Length == 0)
        {
            Debug.LogWarning("No footstep clips assigned!");
            return;
        }

        // Play a random footstep sound
        AudioClip clip = footstepClips[Random.Range(0, footstepClips.Length)];
        audioSource.PlayOneShot(clip, footstepVolume);
    }

    public void SetStepInterval(float newInterval)
    {
        stepInterval = Mathf.Max(0.1f, newInterval); // Ensure interval is not too low
    }
}
