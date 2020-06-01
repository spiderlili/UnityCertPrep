using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a single SE can sound like several different takes by randomly varying the pitch slightly in either direction
public class RandomAudioPitch : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        if(audioSource == null)
        {
            audioSource = this.gameObject.GetComponent<AudioSource>();
            clip = this.gameObject.GetComponent<AudioClip>();
        }
        PlayAtRandomPitch(audioSource, clip, 0.95f, 1.05f);
    }

    public void PlayAtRandomPitch(AudioSource audio, AudioClip clip, float minPitch = 0.95f, float maxPitch = 1.05f)
    {
        float originalPitch = audio.pitch;
        audio.pitch = Random.Range(minPitch, maxPitch);
        audio.PlayOneShot(clip);
        //audio.pitch = originalPitch;
    }
}
