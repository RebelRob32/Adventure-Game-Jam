using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AGJ.Player
{
public partial class PlayerStateManager : MonoBehaviour
{
        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            input = GetComponent<PlayerInput>();
            walkSpeed = 5f;
            sprintSpeed = 10f;
            rotationSpeed = 2.5f;
            health = 100;
            fearLevel = 0;

            gravity = new Vector3(0, -9.81f, 0);
        }

        public void Start()
        {
            currentState = idleState;
            currentState.EnterState(this);
        }

        public void Update()
        {
            Debug.Log("" + currentState);
            TrackHealthandFear();

            if(currentState != jumpState && currentState != fallState && !controller.isGrounded)
            {
                SwitchState(fallState);
            }

            currentState.UpdateState(this);
            Gravity();
        }

        public void SwitchState(PlayerBaseState state)
        {
            currentState.ExitState(this);
            currentState = state;
            state.EnterState(this);
        }

        public void Gravity()
        {
            controller.Move(gravity * Time.deltaTime);
        }

        public void Move()
        {
            controller.Move(walkSpeed * moveVector * Time.deltaTime);
            Rotate();
        }

        public void Sprint()
        {
            controller.Move(sprintSpeed * moveVector * Time.deltaTime);
            Rotate();
        }

        public void CrouchDown()
        {
            //player crouches, becoming less visible to enemies when hiding behind things
        }

        public void Rotate()
        {
            var xzDir = new Vector3(moveVector.x, 0, moveVector.z);
            if(xzDir.magnitude == 0)
            {
                return;
            }

            var rotation = Quaternion.LookRotation(xzDir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed);
        }

        public void TrackHealthandFear()
        {
            healthSlider.value = health;
            fearSlider.value = fearLevel;
        }

        public void Attack()
        {
            //fires attack animation
            
        }

        public void TakeDamage(float amount)
        {
            health -= amount;
            if (health <= 0f)
            {
                Die();
            }
        }

        public void Die()
        {
            Debug.Log("Player Dead, Game Over");
        }

    }


}

