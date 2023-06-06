using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AGJ.Player
{
    public class PlayerRunState : PlayerBaseState
    {
        public override void EnterState(PlayerStateManager player)
        {
            
        }

        public override void ExitState(PlayerStateManager player)
        {
            

        }

        public override void UpdateState(PlayerStateManager player)
        {

            if (player.currentState != player.walkState || player.currentState != player.idleState)
            {
                player.Sprint();
            }
           
            
        }
    }
}
