using UnityEngine;

namespace Game.Scripts.GameMechanics.Player
{
    public class PlayerTarget : MonoBehaviour, ITarget
    {
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius,
            float upwardsModifier = 0, ForceMode mode = ForceMode.Force)
        {
            _rigidbody.AddExplosionForce(explosionForce, explosionPosition, explosionRadius, upwardsModifier, mode);
        }
    }
}