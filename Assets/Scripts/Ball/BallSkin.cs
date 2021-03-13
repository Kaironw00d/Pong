using UnityEngine;

[CreateAssetMenu(fileName = "Ball Skin", menuName = "Custom/Ball/Ball Skin", order = 0)]
public class BallSkin : ScriptableObject, ISkin
{
    [SerializeField] private int indexInDatabase;
    public int IndexInDatabase => indexInDatabase;
    public Color skinColor;
    public Gradient trailGradient;
    public Color firstExplosionColor;
    public Color secondExplosionColor;
}