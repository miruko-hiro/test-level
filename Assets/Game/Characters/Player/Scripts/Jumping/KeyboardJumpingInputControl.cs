using UnityEngine;

namespace Game.Characters.Player.Scripts.Jumping
{
    public class KeyboardJumpingInputControl: IJumpingInputControl
    {
        public bool CurrentInput()
        {
            return Input.GetButtonDown("Jump");
        }
    }
}