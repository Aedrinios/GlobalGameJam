using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioClip[] sound;
    [Range(0,1)] public float volume;

    AudioSource source;
    private void Start()
    {
        source = GetComponent<AudioSource>(); 
    }

    public void PlaySound()
    {
        source.volume = volume; 
        int i = Random.Range(0, sound.Length);
        source.PlayOneShot(sound[i]); 
    }
}
