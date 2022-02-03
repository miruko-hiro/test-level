using UnityEngine;

namespace Game.Scripts.GameMechanics.Player.Shooting
{
    public class MouseShootingInputControl: IShootingInputControl
    {
        public bool CurrentInput()
        {
            return Input.GetButton("Fire1");
        }
    }
}