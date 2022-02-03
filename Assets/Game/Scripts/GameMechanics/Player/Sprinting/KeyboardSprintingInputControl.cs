using UnityEngine;

namespace Game.Scripts.GameMechanics.Player.Sprinting
{
    public class KeyboardSprintingInputControl: ISprintingInputControl
    {
        private KeyCode _sprintKey = KeyCode.LeftShift;
        
        public bool CurrentInput()
        {
            return Input.GetKey(_sprintKey);
        }
    }
}