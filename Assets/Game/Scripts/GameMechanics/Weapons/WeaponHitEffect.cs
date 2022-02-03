using UnityEngine;

namespace Game.Scripts.GameMechanics.Weapons
{
    public class WeaponHitEffect: IHitEffect
    {
        private readonly ParticleSystem _bulletExplosionParticle;
        private readonly Transform _transformBulletExplosion;

        public WeaponHitEffect()
        {
            _bulletExplosionParticle = Object.Instantiate(Resources.Load<ParticleSystem>("Bullet Explosion"));
            _transformBulletExplosion = _bulletExplosionParticle.GetComponent<Transform>();
            _transformBulletExplosion.position = new Vector3(0f, 50f, 0f);
        }

        public void Show(Vector3 position, Quaternion rotation)
        {
            _transformBulletExplosion.position = position;
            _transformBulletExplosion.rotation = rotation;
            _bulletExplosionParticle.Play();
        }
    }
}