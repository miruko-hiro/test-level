using System;
using UnityEngine;

namespace Game.Weapons.Scripts.Balls
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
    }
}