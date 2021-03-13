using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour, ITarget
{
    public GameObjectPool Pool { get; set; }
    [SerializeField] private BallSettings settings;
    public ITargetSettings Settings => settings;
    private IAudioService _audioService;
    
    private float _speed;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private TrailRenderer _trailRenderer;
    private ParticleSystem _particleSystem;

    private void Awake()
    {
        _audioService = GameObject.FindWithTag("Audio Service").GetComponent<IAudioService>();
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _trailRenderer = GetComponentInChildren<TrailRenderer>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _particleSystem.transform.SetParent(null);
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
        var main = _particleSystem.main;
        main.startColor =
            new ParticleSystem.MinMaxGradient(settings.GetFirstExplosionColor(), settings.GetSecondExplosionColor());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _audioService.Play(SoundType.Impact);
        _particleSystem.transform.position = other.GetContact(0).point;
        _particleSystem.Play();
    }
}