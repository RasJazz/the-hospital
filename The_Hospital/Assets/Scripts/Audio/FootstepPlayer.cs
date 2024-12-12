using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepPlayer : MonoBehaviour
{
    private AudioSource audioSource; // AudioSource for footstep sounds
    private Player player; // Reference to the Player script

    public AudioClip[] footstepClips; // Array of footstep sounds
    public float stepInterval = 0.5f; // Time between footsteps
    [Range(0f, 1f)] public float footstepVolume = 0.5f; // Volume of the footsteps

    private float stepTimer = 0f; // Timer to track time between steps

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GetComponent<Player>();

        if (!audioSource)
        {
            Debug.LogError("AudioSource component is missing!");
        }

        if (!player)
        {
            Debug.LogError("Player component is missing!");
        }
    }

    void Update()
    {
        // Check if the player is moving
        if (IsPlayerMoving())
        {
            stepTimer += Time.deltaTime;
            if (stepTimer >= stepInterval)
            {
                PlayFootstepSound();
                stepTimer = 0f; // Reset the timer
            }
        }
        else
        {
            stepTimer = 0f; // Reset the timer if the player stops
        }
    }

    bool IsPlayerMoving()
    {
        // Check if the inputDirection from the Player script is non-zero
        return player != null && player.GetInputDirection().sqrMagnitude > 0.01f;
    }

    void PlayFootstepSound()
    {
        if (footstepClips.Length > 0 && audioSource)
        {
            // Randomly select a footstep sound from the array
            AudioClip clip = footstepClips[Random.Range(0, footstepClips.Length)];
            audioSource.PlayOneShot(clip, footstepVolume);
        }
    }
}
