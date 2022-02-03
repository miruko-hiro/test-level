using UnityEngine;

namespace Game.Scripts.GameMechanics.Player
{
    public interface ITarget
    {
        public void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius, 
            float upwardsModifier = 0.0f, ForceMode mode = ForceMode.Force);
    }
}