using UnityEngine;

namespace Game.Scripts.GameMechanics.Player.Aiming
{
    public class MouseAimingInputControl: IAimingInputControl
    {
        public bool CurrentInput()
        {
            return Input.GetButton("Fire2");
        }
    }
}