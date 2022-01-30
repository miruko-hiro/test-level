using UnityEngine;

namespace Game.Player.Scripts.Jumping
{
    public class KeyboardJumpingInputControl: IJumpingInputControl
    {
        public bool CurrentInput()
        {
            return Input.GetButtonDown("Jump");
        }
    }
}