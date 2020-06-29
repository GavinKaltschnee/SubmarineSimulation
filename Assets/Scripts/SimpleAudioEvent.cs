using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "New Simple Audio Event", menuName = "Audio Events/Simple Audio Event")]
public class SimpleAudioEvent : AudioEvent
{
    [SerializeField] private AudioClip audioClip = null;
    [SerializeField] private AudioMixerGroup audioMixerGroup = null;

    [SerializeField] [Range(0, 1)] private float volume = 1;
    [SerializeField] [Range(0, 2)] private float pitch = 1;

    public override void Play(AudioSource audioSource)
    {
        if (!audioClip)
            return;

        audioSource.outputAudioMixerGroup = audioMixerGroup;
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        audioSource.Play();
    }
}
