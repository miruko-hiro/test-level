using UnityEngine;

namespace Game.Player.Scripts.Aiming
{
    public class MouseAimingInputControl: IAimingInputControl
    {
        public bool CurrentInput()
        {
            return Input.GetButton("Fire2");
        }
    }
}