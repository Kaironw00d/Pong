using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Skins Database", menuName = "Custom/Player/PlayerSkinsDatabase", order = 0)]
public class PlayerSkinsDatabase : BaseSkinDatabase<PlayerSkin>
{
    [SerializeField] private List<PlayerSkin> skinsList = new List<PlayerSkin>();
    protected override List<PlayerSkin> SkinsList => skinsList;
    public override Dictionary<int, PlayerSkin> Skins { get; protected set; }
}