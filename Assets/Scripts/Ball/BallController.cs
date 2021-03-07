using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour, ITarget
{
    public GameObjectPool Pool { get; set; }
    [SerializeField] private BallSettings settings;
    public ITargetSettings Settings => settings;
    
    private float _speed;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private TrailRenderer _trailRenderer;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _trailRenderer = GetComponentInChildren<TrailRenderer>();
        Settings.Init();
    }

    private void OnEnable() => Launch();

    private void OnDisable() => Pool.ReturnToPool(gameObject);

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        _rigidbody.velocity = new Vector2(_speed * x,_speed * y);
    }

    public void ApplySettings()
    {
        _transform.position = Settings.SpawnPosition;
        _transform.rotation = Quaternion.Euler(Settings.SpawnRotation);
        _transform.localScale = Vector3.one * Random.Range(Settings.MinSize, Settings.MaxSize);
        _speed = Random.Range(Settings.MinSpeed, Settings.MaxSpeed);
        _spriteRenderer.color = settings.GetSkinColor();
        _trailRenderer.colorGradient = settings.GetSkinGradient();
    }
}