using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AGJ.Player
{
public class PlayerIdleState : PlayerBaseState
{
        public override void EnterState(PlayerStateManager player)
        {

        }

        public override void ExitState(PlayerStateManager player)
        {

        }

        public override void UpdateState(PlayerStateManager player)
        {
            if(player.moveVector.magnitude != 0)
            {
                player.SwitchState(player.walkState);
            }
        }
    }
}


