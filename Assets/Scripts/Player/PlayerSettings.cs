using UnityEngine;

[CreateAssetMenu(fileName = "Player Settings", menuName = "Custom/Player/Player Settings", order = 0)]
public class PlayerSettings : ScriptableObject, IPlayerSettings
{
    [SerializeField] private PlayerSkinsDatabase skinsDatabase;
    public BaseSkinDatabase<PlayerSkin> SkinDatabase => skinsDatabase;
    [SerializeField] private int speed;
    public int Speed => speed;
    [SerializeField] private Vector3 spawnPosition;
    public Vector3 SpawnPosition => spawnPosition;
    [SerializeField] private Vector3 spawnRotation;
    public Vector3 SpawnRotation => spawnPosition;
    public void Init() => SkinDatabase.Init();

    public Sprite GetSkinSprite(PlayerPrefsKey playerPrefsKey)
    {
        return SkinDatabase.Skins[PlayerPrefs.GetInt(playerPrefsKey.ToString(), (int)playerPrefsKey)].skinSprite;
    }
}