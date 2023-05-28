using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AGJ.Player
{
    public class PlayerFallState : PlayerBaseState
    {
        public override void EnterState(PlayerStateManager player)
        {

        }

        public override void ExitState(PlayerStateManager player)
        {

        }

        public override void UpdateState(PlayerStateManager player)
        {
           if(player.controller.isGrounded)
            {
                player.SwitchState(player.idleState);
            }
           else
            {
                player.Move();
                player.Rotate();
            }
        }
    }
}
