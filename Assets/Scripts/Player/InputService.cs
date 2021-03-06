using System;
using UnityEngine;

public class InputService : MonoBehaviour, IInputService
{
    private InputActions _inputActions;

    public float Player1Axis { get; private set; }
    public float Player2Axis { get; private set; }
    private void Awake()
    {
        _inputActions = new InputActions();

        _inputActions.Player1.Move.performed += context => Player1Axis = context.ReadValue<float>();
        _inputActions.Player2.Move.performed += context => Player2Axis = context.ReadValue<float>();
    }

    private void OnEnable() => _inputActions.Enable();

    private void OnDisable()
    {
        Player1Axis = 0;
        Player2Axis = 0;
    }
}