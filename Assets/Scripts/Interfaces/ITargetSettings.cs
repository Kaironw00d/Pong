using UnityEngine;

public interface ITargetSettings
{
    float MinSpeed { get; }
    float MaxSpeed { get; }
    Vector3 SpawnPosition { get; }
    Vector3 SpawnRotation { get; }
}