using System;
using UnityEngine;
using UnityEngine.UI;

public class BallSkinChanger : MonoBehaviour, ISkinChanger
{
    [SerializeField] private BallSettings ballSettings;
    public ITargetSettings TargetSettings => ballSettings;
    [SerializeField] private BallSkin ballSkin;
    
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetCustomization);
    }

    private void SetCustomization()
    {
        PlayerPrefs.SetInt("Ball Skin", ballSkin.indexInDatabase);
    }
}