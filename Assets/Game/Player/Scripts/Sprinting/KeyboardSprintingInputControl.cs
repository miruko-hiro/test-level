using UnityEngine;

namespace Game.Player.Scripts.Sprinting
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