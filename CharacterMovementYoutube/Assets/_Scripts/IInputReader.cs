using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IInputReader
{
    public Vector3 MoveDirection { get;}
}

public class NewInputReader : IInputReader
{
    public Vector3 MoveDirection { get; private set; }

    public NewInputReader()
    {
        var input = new GameInputActions();
        
        input.Player.Move.performed += HandleOnMovement;
        input.Player.Move.canceled += HandleOnMovement;
        
        input.Enable();
    }
    
    void HandleOnMovement(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        MoveDirection = new Vector3(direction.x, 0f, direction.y);
    }
}

public class OldInputReader : IInputReader
{
    public Vector3 MoveDirection
    {
        get
        {
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");

            return new Vector3(x, 0f, z);
        }
    }
}