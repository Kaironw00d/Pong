using UnityEngine;
using UnityEngine.Audio;

public class AudioService : MonoBehaviour, IAudioService
{
    [SerializeField] private AudioMixerGroup mixer;
    [SerializeField] private Sound[] sounds;

    private void Awake()
    {
        for (var i = 0; i < sounds.Length; i++)
        {
            var go = new GameObject($"[{sounds[i].type}]AudioSource");
            go.transform.SetParent(this.transform);
            sounds[i].Init(go.AddComponent<AudioSource>());
        }
    }

    public void Play(SoundType soundType)
    {
        for (var i = 0; i < sounds.Length; i++)
        {
            var sound = sounds[i];
            if(sound.type == soundType)
                sound.Play();
        }
    }

    public void ToggleMusic(bool value)
    {
        mixer.audioMixer.SetFloat("Music", !value ? -80 : 0);
    }

    public void ToggleSounds(bool value)
    {
        mixer.audioMixer.SetFloat("Sounds", !value ? -80 : 0);
    }
}