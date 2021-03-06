using UnityEngine;

namespace Game.Scripts.GameMechanics.Core
{
    public class KeyboardMenuInputControl: IMenuInputControl
    {
        private KeyCode _keyCode = KeyCode.Escape;
        
        public bool CurrentInput()
        {
            return Input.GetKeyDown(_keyCode);
        }
    }
}