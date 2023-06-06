using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AGJ.Player
{
    public class PlayerWalkState : PlayerBaseState
    {
        public override void EnterState(PlayerStateManager player)
        {

        }

        public override void ExitState(PlayerStateManager player)
        {

        }

        public override void UpdateState(PlayerStateManager player)
        {
            if (player.moveVector.magnitude == 0)
            {
                player.SwitchState(player.idleState);
            }
            else if (player.currentState != player.runState)
            {
                player.Move();
            }
        }
    }
}
