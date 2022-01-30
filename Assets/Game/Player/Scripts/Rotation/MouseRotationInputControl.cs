using UnityEngine;

namespace Game.Player.Scripts.Rotation
{
    public class MouseRotationInputControl: IRotationInputControl
    {
        public (float, float) CurrentInput()
        {
            return (Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }
    }
}