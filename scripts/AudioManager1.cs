using UnityEngine.Audio;
using System;
using UnityEngine;

// Credit to Brackeys youtube tutorial and Valem youtube tutorial for the audio manager script

public class AudioManager1 : MonoBehaviour
{
    public string name;
    public AudioClip clip;
    [Range(0, 1)]
    public float volume = 1;
    [Range(-3, 3)]
    public float pitch = 1;
    public bool loop = false;
    public bool PlayOnAwake = false;
    public AudioSource source;

    void Awake()
    {
        if (!source)
            source = gameObject.AddComponent<AudioSource>();

        source.clip = clip;
        source.playOnAwake = PlayOnAwake;

        if (PlayOnAwake)
            source.Play();

        source.volume = volume;
        source.pitch = pitch;
        source.loop = loop;

    }

    public void Play()
    {
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
    }
}