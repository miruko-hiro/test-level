using UnityEngine;

namespace Game.Scripts.GameMechanics.Player.Movement
{
    public class KeyboardMovementInputControl: IMovementInputControl
    {
        public (float, float) CurrentInput()
        {
            return (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
    }
}