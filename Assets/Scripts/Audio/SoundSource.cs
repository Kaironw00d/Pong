using System;
using UnityEngine;

public class SoundSource : MonoBehaviour
{
    public Action playSoundDelegate;
    public SoundType soundType;

    public void InvokePlaySoundDelegate() => playSoundDelegate?.Invoke();
}