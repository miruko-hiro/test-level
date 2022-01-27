using UnityEngine;

namespace Game.Characters.Player.Scripts.Rotation
{
    public class MouseRotationInputControl: IRotationInputControl
    {
        public (float, float) CurrentInput()
        {
            return (Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }
    }
}