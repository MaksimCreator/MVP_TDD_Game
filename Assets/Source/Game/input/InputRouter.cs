using System;
using UnityEngine.InputSystem;

class InputRouter : IInputRouter,IControl
{
    private PlayerInput _input = new PlayerInput();

    public event Action onTap;

    public void Enable()
    { 
        _input.Enable();
        _input.Character.Click.performed += OnTap;
    }

    public void Disable()
    {
        _input.Disable();
        _input.Character.Click.performed -= OnTap;
    }

    private void OnTap(InputAction.CallbackContext obj)
    => onTap.Invoke();
}
