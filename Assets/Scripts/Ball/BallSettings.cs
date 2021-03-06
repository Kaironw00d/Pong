using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ball Settings", menuName = "Custom/Ball Settings", order = 0)]
public class BallSettings : ScriptableObject, ITargetSettings
{
    [SerializeField] private BallSkinsDatabase skinsDatabase; 
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

    public void Init() => skinsDatabase.Init();

    public Color GetSkinColor()
    {
        return skinsDatabase.skins[PlayerPrefs.GetInt("Ball Skin", 0)].skinColor;
    }

    public Gradient GetSkinGradient()
    {
        return skinsDatabase.skins[PlayerPrefs.GetInt("Ball Skin", 0)].trailGradient;
    }
}