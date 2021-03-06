using UnityEngine;
using UnityEngine.UI;

public class BallCustomizer : MonoBehaviour, ICustomizer
{
    [SerializeField] private BallSettings ballSettings;
    public ITargetSettings TargetSettings => ballSettings;
    public Color color;
    public Gradient trailGradient;
    
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetCustomization);
    }

    private void SetCustomization()
    {
        ballSettings.color = color;
        ballSettings.trailGradient = trailGradient;
    }
}