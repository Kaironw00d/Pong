using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ball Customization Database", menuName = "Custom/Ball Customization Database", order = 0)]
public class BallSkinsDatabase : ScriptableObject
{
    [SerializeField] private List<BallSkin> ballSkins = new List<BallSkin>();
    public Dictionary<int, BallSkin> skins = new Dictionary<int, BallSkin>();

    public void Init()
    {
        for (var i = 0; i < ballSkins.Count; i++)
        {
            var skin = ballSkins[i];
            skins.Add(skin.indexInDatabase, skin);
        }
    }
}