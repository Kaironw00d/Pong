using System;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public class Sound
{
    public SoundType type;
    public AudioClip clip;
    public AudioMixerGroup mixer;
    public bool loop;
    public bool playOnAwake;
    [Range(0f, 1f)] public float volume;
    [Range(0.5f, 1.5f)] public float pitch;

    private AudioSource _source;

    public void Init(AudioSource source)
    {
        _source = source;

        _source.clip = clip;
        _source.outputAudioMixerGroup = mixer;
        _source.loop = loop;
        _source.playOnAwake = playOnAwake;
        _source.volume = volume;
        _source.pitch = pitch;
        
        if(playOnAwake)
            Play();
    }

    public void Play()
    {
        _source.Play();
    }
}