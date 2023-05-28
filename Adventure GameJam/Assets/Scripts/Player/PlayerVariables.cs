using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace AGJ.Player
{
public partial class PlayerStateManager
{
    public CharacterController controller;

    public PlayerInput input;

    public Vector3 moveVector;
    public Vector2 inputVector;

    public float rotationSpeed;
    public float walkSpeed;

    private Vector3 gravity;
}
}

