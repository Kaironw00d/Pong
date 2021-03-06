using UnityEngine;

[CreateAssetMenu(fileName = "New Ball Settings", menuName = "Custom/Ball Settings", order = 0)]
public class BallSettings : ScriptableObject, ITargetSettings
{
    [SerializeField] private float minSpeed;
    public float MinSpeed => minSpeed;
    [SerializeField] private float maxSpeed;
    public float MaxSpeed => maxSpeed;
    [SerializeField] private Vector3 spawnPosition;
    public Vector3 SpawnPosition => spawnPosition;
    [SerializeField] private Vector3 spawnRotation;
    public Vector3 SpawnRotation => spawnRotation;
    public float minSize;
    public float maxSize;
    public Color color;
    public Gradient trailGradient;
}