using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Creates instance of AudioManager to be used throughout game
    public static AudioManager Instance;

    public Sound musicSound;
    public Sound[] sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        /*
        If there is no instance, assigns current game object
        as current instance and prevents it from being
        destroyed on scene switch
        */
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Plays music at start of the game
    private void Start()
    {
        PlayMusic(musicSound);
    }

    /// <summary>
    /// This function is used to play the music for the game.
    /// </summary>
    /// <param name="s">The music to be played on game start</param>
    private void PlayMusic(Sound s)
    {
        if (s == null) { Debug.Log("Sound not found");}
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    /// <summary>
    /// This function is used to play sound effect One Shots.
    /// </summary>
    /// <param name="name">The name of the sfx audio clip to be played</param>
    public void PlaySfx(string name)
    {
        // Finds the specified sound in the array
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        
        // If sound not found, returns an error
        // else, plays the sound clip
        if (s == null) { Debug.Log("Sound not found");}
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    internal void Play(string v)
    {
        throw new NotImplementedException();
    }
}
