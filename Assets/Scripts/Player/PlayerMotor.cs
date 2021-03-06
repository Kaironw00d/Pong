using System;
using UnityEngine;

public enum PlayerID
{
    Player1,
    Player2
}
public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private PlayerID playerID;
    [SerializeField] private float speed = 4;
    [SerializeField] private Vector3 startPosition;
    
    private IInputService _inputService;
    private Rigidbody2D _rigidbody;
    private float _movement;

    private void Awake()
    {
        _inputService = GetComponent<IInputService>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        transform.position = startPosition;
        _movement = 0;
    }

    private void Update()
    {
        _movement = playerID == PlayerID.Player1 ? _inputService.Player1Axis : _inputService.Player2Axis;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _movement * speed);
    }
}