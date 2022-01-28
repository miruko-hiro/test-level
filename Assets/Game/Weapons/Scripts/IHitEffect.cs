using UnityEngine;

namespace Game.Weapons.Scripts
{
    public interface IHitEffect
    {
        public void Show(Vector3 position, Quaternion rotation);
    }
}