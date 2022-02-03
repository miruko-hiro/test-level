using UnityEngine;

namespace Game.Scripts.GameMechanics.Weapons
{
    public interface IHitEffect
    {
        public void Show(Vector3 position, Quaternion rotation);
    }
}