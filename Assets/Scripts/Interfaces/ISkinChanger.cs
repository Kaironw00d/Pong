public interface ISkinChanger
{
    PlayerPrefsKey PlayerPrefsKey { get; }
    ISkin Skin { get; }
    void SetSkin();
}