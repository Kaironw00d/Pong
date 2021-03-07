using UnityEngine;
using UnityEngine.UI;

public class PlayerSkinChanger : MonoBehaviour, ISkinChanger
{
    [SerializeField] private PlayerPrefsKey playerPrefsKey;
    public PlayerPrefsKey PlayerPrefsKey => playerPrefsKey;
    [SerializeField] private PlayerSkin playerSkin;
    public ISkin Skin => playerSkin;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetSkin);
    }

    public void SetSkin()
    {
        PlayerPrefs.SetInt(PlayerPrefsKey.ToString(), Skin.IndexInDatabase);
    }
}