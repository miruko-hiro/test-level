using UnityEngine;

namespace Game.Player.Scripts
{
    public interface ITarget
    {
        public void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius, 
            float upwardsModifier = 0.0f, ForceMode mode = ForceMode.Force);
    }
}