using System;
using Game.Scripts;
using UnityEngine;

namespace Game.Weapons.Scripts
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField][Min(0.5f)] private float _timeBetweenShots = 2f;
        [SerializeField][Min(0)] private int _damage = 1;
        [SerializeField][Min(1f)] private float _weaponRange = 50f;

        private IHitEffect _hitEffect;
        private IShootEffect _shootEffect;
        private float _nextFire;
        private int _impactLayerIndex;

        private void Awake()
        {
            _hitEffect = GetComponentInChildren<IHitEffect>();
            _shootEffect = GetComponentInChildren<IShootEffect>();
            _impactLayerIndex = LayerMask.GetMask("Impact");
        }

        public bool CanShoot()
        {
            return Time.time > _nextFire;
        }

        public void Shoot(Vector3 rayOrigin, Vector3 cameraTransformForward)
        {
            _nextFire = Time.time + _timeBetweenShots;

            if (Physics.Raycast(rayOrigin, cameraTransformForward, out var hit, _weaponRange, _impactLayerIndex))
            {
                var damageRecipient = hit.transform.GetComponent<IDamageRecipient>();
                damageRecipient?.Hit(_damage);
                HitEffect(hit.point, Quaternion.LookRotation(hit.normal));
            }

            ShootEffect();
        }

        private void HitEffect(Vector3 position, Quaternion rotation)
        {
            _hitEffect?.Show(position, rotation);
        }

        private void ShootEffect()
        {
            _shootEffect?.Show();
        }
    }
}