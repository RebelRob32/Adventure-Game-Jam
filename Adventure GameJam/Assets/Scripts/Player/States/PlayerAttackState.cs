using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AGJ.Player
{
    public class PlayerAttackState : PlayerBaseState
    {
        public override void EnterState(PlayerStateManager player)
        {

        }

        public override void ExitState(PlayerStateManager player)
        {

        }

        public override void UpdateState(PlayerStateManager player)
        {
            player.Attack();
        }
    }
}