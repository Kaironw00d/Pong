using UnityEngine;

public interface ISettings
{
    Vector3 SpawnPosition { get; }
    Vector3 SpawnRotation { get; }
    void Init();
}