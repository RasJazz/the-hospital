using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    private Player player;

    public AudioClip[] footstepClips; // Array of footstep sounds
    public float stepInterval = 0.5f; // Time between footsteps
    [Range(0f, 1f)] public float footstepVolume = 0.5f; // Volume of the footsteps

    private float stepTimer = 0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GetComponent<Player>();

        if (!audioSource) Debug.LogError("AudioSource component is missing!");
        if (!player) Debug.LogError("Player component is missing!");
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
            stepTimer = 0f;
        }
    }

    bool IsPlayerMoving()
    {
        return true;
        //return player.GetInputDirection().sqrMagnitude > 0.01f;
    }

    void PlayFootstepSound()
    {
        if (footstepClips.Length > 0)
        {
            AudioClip clip = footstepClips[Random.Range(0, footstepClips.Length)];
            audioSource.PlayOneShot(clip, footstepVolume);
        }
    }
}
