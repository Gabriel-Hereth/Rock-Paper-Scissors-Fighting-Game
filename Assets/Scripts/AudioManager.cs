using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundList
{
    rockPlayerSFXIndex,
    paperPlayerSFXIndex,
    scissorsPlayerSFXIndex
}

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    private AudioSource audioSource;
    public SoundFX[] soundFX;

    private void Awake()
    {
        instance = this;
        audioSource = instance.GetComponent<AudioSource>();
    }

    public static void PlaySound(/*soundLibrary index, soundFX index, volume, position (maybe optional)*/)
    {
        //instance.audioSource.PlayOneShot();
    }

    public static void PlaySoundAtPosition()
    {

    }

    public static void PlayRandomSound()
    {

    }

    public static void PlayRandomSoundAtPosition()
    {

    }
    
}
