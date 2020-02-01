using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] sound;
    [Range(0,1)] public float volume = 1;
    public float modifVolumeNext = 0; 

    public void PlaySound()
    {
        GameObject newSound = new GameObject("newSound");
        newSound.AddComponent<AudioSource>();
        AudioSource source = newSound.GetComponent<AudioSource>();
        newSound.AddComponent<DestroyAfter>();
        source.volume = volume; 
        int i = Random.Range(0, sound.Length);
        source.PlayOneShot(sound[i]);
        volume += modifVolumeNext; 
    }
}
