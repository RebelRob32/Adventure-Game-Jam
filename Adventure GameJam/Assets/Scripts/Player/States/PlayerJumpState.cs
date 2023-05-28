using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AGJ.Player
{
    public class PlayerJumpState : PlayerBaseState
    {
        public float jumpForce = .1f;
        public int maxForce = 5;
        public override void EnterState(PlayerStateManager player)
        {

        }

        public override void ExitState(PlayerStateManager player)
        {
            player.moveVector.y = 0;
        }

        public override void UpdateState(PlayerStateManager player)
        {
            player.moveVector.y += jumpForce;

            if(player.moveVector.y >= maxForce)
            {
                player.SwitchState(player.fallState);
            }

            player.Move();
        }
    }
}

