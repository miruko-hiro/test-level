using UnityEngine;

namespace Game.Weapons.Scripts
{
    [RequireComponent(typeof(ParticleSystem))]
    public class Bullet: MonoBehaviour
    {
        private ParticleSystem _particleSystem;
        private Transform _transform;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _particleSystem = GetComponent<ParticleSystem>();
        }

        public void Explode(Vector3 position, Quaternion rotation)
        {
            _transform.position = position;
            transform.rotation = rotation;
            _particleSystem.Play();
        }
    }
}