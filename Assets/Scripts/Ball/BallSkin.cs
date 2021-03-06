using UnityEngine;

[CreateAssetMenu(fileName = "Ball Skin", menuName = "Custom/Ball Skin", order = 0)]
public class BallSkin : ScriptableObject
{
    public int indexInDatabase;
    public Color skinColor;
    public Gradient trailGradient;

    // private void OnValidate()
    // {
    //     trailGradient.SetKeys(new [] {new GradientColorKey(skinColor, 0), new GradientColorKey(Color.white, 1) }, new [] { new GradientAlphaKey(255, 0), new GradientAlphaKey(155, 1) });
    // }
}