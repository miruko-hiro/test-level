using UnityEngine;

namespace Game.Weapons.Scripts
{
    public class WeaponHitEffect: MonoBehaviour, IHitEffect
    {
        [SerializeField] private ParticleSystem _bulletExplosionParticle;
        private Transform _transformBulletExplosion;

        private void Awake()
        {
            _transformBulletExplosion = _bulletExplosionParticle.GetComponent<Transform>();
        }

        public void Show(Vector3 position, Quaternion rotation)
        {
            _transformBulletExplosion.position = position;
            _transformBulletExplosion.rotation = rotation;
            _bulletExplosionParticle.Play();
        }
    }
}