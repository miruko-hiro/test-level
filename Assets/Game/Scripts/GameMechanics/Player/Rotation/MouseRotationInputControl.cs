using UnityEngine;

namespace Game.Scripts.GameMechanics.Player.Rotation
{
    public class MouseRotationInputControl: IRotationInputControl
    {
        public (float, float) CurrentInput()
        {
            return (Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }
    }
}