public enum SoundType
{
    Ambient,
    Impact,
    Click,
    Return,
    Select
}

public interface IAudioService
{
    void Play(SoundType soundType);
    void ToggleMusic(bool value);
    void ToggleSounds(bool value);
}