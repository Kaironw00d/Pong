using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ball Skins Database", menuName = "Custom/Ball/Ball Skins Database", order = 0)]
public class BallSkinsDatabase : BaseSkinDatabase<BallSkin>
{
    [SerializeField] private List<BallSkin> skinsList = new List<BallSkin>();
    protected override List<BallSkin> SkinsList => skinsList;
    public override Dictionary<int, BallSkin> Skins { get; protected set; }
}