using UnityEngine;

public enum PlayerID
{
    Player1,
    Player2
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerID playerID;
    [SerializeField] private PlayerSettings settings;
    
    private IInputService _inputService;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private float _speed;
    private float _movement;

    private void Awake()
    {
        _inputService = GetComponent<IInputService>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        settings.Init();
    }

    private void OnEnable()
    {
        ApplySettings();
        _movement = 0;
    }

    private void ApplySettings()
    {
        transform.position = settings.SpawnPosition;
        transform.rotation = Quaternion.Euler(settings.SpawnRotation);
        _speed = settings.Speed;
        _spriteRenderer.sprite = settings.GetSkinSprite(playerID == PlayerID.Player1 ? PlayerPrefsKey.Player1Skin : PlayerPrefsKey.Player2Skin);
    }

    private void Update()
    {
        _movement = playerID == PlayerID.Player1 ? _inputService.Player1Axis : _inputService.Player2Axis;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _movement * _speed);
    }
}