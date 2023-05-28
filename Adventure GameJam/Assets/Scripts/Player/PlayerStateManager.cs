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
            rotationSpeed = 2.5f;

            gravity = new Vector3(0, -9.81f, 0);
        }

        public void Update()
        {
            Move();
            Rotate();
            Gravity();
        }

        public void Gravity()
        {
            controller.Move(gravity * Time.deltaTime);
        }

        public void Move()
        {
            controller.Move(walkSpeed * moveVector * Time.deltaTime);
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

    }


}

