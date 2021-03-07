using UnityEngine;

[CreateAssetMenu(fileName = "Player Skin", menuName = "Custom/Player/Player Skin", order = 0)]
public class PlayerSkin : ScriptableObject, ISkin
{
    [SerializeField] private int indexInDatabase;
    public int IndexInDatabase => indexInDatabase;
    public Sprite skinSprite;
}