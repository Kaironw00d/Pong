using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkinDatabase<TSkin> : ScriptableObject where TSkin : ISkin
{
    protected abstract List<TSkin> SkinsList { get; }
    public abstract Dictionary<int, TSkin> Skins { get; protected set; }
    
    public virtual void Init()
    {
        Skins = new Dictionary<int, TSkin>();
        for (var i = 0; i < SkinsList.Count; i++)
        {
            var skin = SkinsList[i];
            Skins.Add(skin.IndexInDatabase, skin);
        }
    }
}