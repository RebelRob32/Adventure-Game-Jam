using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace AGJ.Player
{
public partial class PlayerStateManager
{
        public PlayerWalkState walkState = new PlayerWalkState();
        public PlayerIdleState idleState = new PlayerIdleState();
        public PlayerRunState runState = new PlayerRunState();
        public PlayerFallState fallState = new PlayerFallState();
        public PlayerJumpState jumpState = new PlayerJumpState();

    public CharacterController controller;

    public PlayerInput input;

        public PlayerBaseState currentState;

    public Vector3 moveVector;
    public Vector2 inputVector;

    public float rotationSpeed;
    public float walkSpeed;
        public float sprintSpeed;

    private Vector3 gravity;
}
}

