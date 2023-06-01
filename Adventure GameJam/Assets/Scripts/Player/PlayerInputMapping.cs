using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AGJ.Player
{
public partial class PlayerStateManager
{
   
        public void OnMove(InputValue value)
        {
            if(currentState != runState)
            {
            inputVector = value.Get<Vector2>();
            moveVector.x = inputVector.x;
            moveVector.z = inputVector.y;
            }
            
        }

       public void OnJump(InputValue value)
        {
            if(currentState != jumpState && currentState != fallState)
            {
                SwitchState(jumpState);
            }
            
            
        }

        public void OnSprint(InputValue value)
        {
           
            SwitchState(runState);
           
        }

        public void OnAttack(InputValue value)
        {
            SwitchState(attackState);
        }

        public void OnCrouch(InputValue value)
        {
            SwitchState(crouchState);
        }
        

}


}

