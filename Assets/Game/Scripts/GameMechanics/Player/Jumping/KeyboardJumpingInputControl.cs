using UnityEngine;

namespace Game.Scripts.GameMechanics.Player.Jumping
{
    public class KeyboardJumpingInputControl: IJumpingInputControl
    {
        public bool CurrentInput()
        {
            return Input.GetButtonDown("Jump");
        }
    }
}