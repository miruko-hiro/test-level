using UnityEngine;

namespace Game.Scripts.GameMechanics.Weapons.Balls
{
    public class BallDeathParticle : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _deathEffectParticle;
        private Transform _transform;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        public void Play(Vector3 position)
        {
            _transform.position = position;
            _deathEffectParticle.Play();
        }

        public void Stop()
        {
            _deathEffectParticle.Stop();
        }
    }
}