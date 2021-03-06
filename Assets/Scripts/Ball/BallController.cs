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
        _transform.position = settings.SpawnPosition;
        _transform.rotation = Quaternion.Euler(settings.SpawnRotation);
        _transform.localScale = Vector3.one * Random.Range(settings.minSize, settings.maxSize);
        _speed = Random.Range(settings.MinSpeed, settings.MaxSpeed);
        _spriteRenderer.color = settings.color;
        _trailRenderer.colorGradient = settings.trailGradient;
    }
}