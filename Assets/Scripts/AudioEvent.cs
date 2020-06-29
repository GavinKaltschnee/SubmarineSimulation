using UnityEngine;
using UnityEngine.Audio;

public abstract class AudioEvent : ScriptableObject
{
    public abstract void Play(AudioSource audioSource);
}
