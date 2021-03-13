using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ball Settings", menuName = "Custom/Ball/Ball Settings", order = 0)]
public class BallSettings : ScriptableObject, ITargetSettings
{
    [SerializeField] private BallSkinsDatabase skinsDatabase;
    public BaseSkinDatabase<BallSkin> SkinsDatabase => skinsDatabase; 
    [SerializeField] private float minSpeed;
    public float MinSpeed => minSpeed;
    [SerializeField] private float maxSpeed;
    public float MaxSpeed => maxSpeed;
    [SerializeField] private Vector3 spawnPosition;
    public Vector3 SpawnPosition => spawnPosition;
    [SerializeField] private Vector3 spawnRotation;
    public Vector3 SpawnRotation => spawnRotation;
    [SerializeField] private float minSize;
    public float MinSize => minSize;
    [SerializeField] private float maxSize;
    public float MaxSize => maxSize;

    public void Init() => SkinsDatabase.Init();

    public Color GetSkinColor()
    {
        return SkinsDatabase.Skins[PlayerPrefs.GetInt(PlayerPrefsKey.BallSkin.ToString(), 0)].skinColor;
    }

    public Gradient GetSkinGradient()
    {
        return SkinsDatabase.Skins[PlayerPrefs.GetInt(PlayerPrefsKey.BallSkin.ToString(), 0)].trailGradient;
    }

    public Color GetFirstExplosionColor()
    {
        return SkinsDatabase.Skins[PlayerPrefs.GetInt(PlayerPrefsKey.BallSkin.ToString(), 0)].firstExplosionColor;
    }
    public Color GetSecondExplosionColor()
    {
        return SkinsDatabase.Skins[PlayerPrefs.GetInt(PlayerPrefsKey.BallSkin.ToString(), 0)].secondExplosionColor;
    }
}