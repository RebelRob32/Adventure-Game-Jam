using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


namespace AGJ.Player
{
public partial class PlayerStateManager
{
        public PlayerWalkState walkState = new PlayerWalkState();
        public PlayerIdleState idleState = new PlayerIdleState();
        public PlayerRunState runState = new PlayerRunState();
        public PlayerFallState fallState = new PlayerFallState();
        public PlayerJumpState jumpState = new PlayerJumpState();
        public PlayerAttackState attackState = new PlayerAttackState();

    public CharacterController controller;

    public PlayerInput input;

        public PlayerBaseState currentState;

    public Vector3 moveVector;
    public Vector2 inputVector;

    public float rotationSpeed;
    public float walkSpeed;
        public float sprintSpeed;

        public float health;
        public float fearLevel;
        public Slider healthSlider;
        public Slider fearSlider;
        

    private Vector3 gravity;
}
}

