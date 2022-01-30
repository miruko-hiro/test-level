using UnityEngine;

namespace Game.Player.Scripts.Movement
{
    public class KeyboardMovementInputControl: IMovementInputControl
    {
        public (float, float) CurrentInput()
        {
            return (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
    }
}