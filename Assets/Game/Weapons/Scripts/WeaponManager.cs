using System;
using Game.Player.Scripts.Shooting;
using Game.Scripts;
using Game.Weapons.Crosshairs.Scripts;
using UnityEngine;

namespace Game.Weapons.Scripts
{
    public class WeaponManager : MonoBehaviour
    {
        [SerializeField] private PlayerShootingSystem _playerShootingSystem;
        [SerializeField][Min(0f)] private float _timeBetweenShots = 2f;
        [SerializeField][Min(0)] private int _damage = 1;

        private IHitEffect _hitEffect;
        private IShootEffect _shootEffect;
        private IWeaponShootAnimation _weaponShootAnimation;
        private ICrosshairChanger _crosshairChangerOnHit;
        private float _nextFire;

        private void Awake()
        {
            _hitEffect = GetComponentInChildren<WeaponHitEffect>();
            _shootEffect = GetComponentInChildren<WeaponShootEffect>();
            _weaponShootAnimation = GetComponentInChildren<WeaponShootAnimation>();
            _crosshairChangerOnHit = GetComponentInChildren<CrosshairChangerOnHit>();
            _playerShootingSystem.EventShootHit += ShootHit;
            _playerShootingSystem.EventShootMissed += ShootMissed;
        }

        private void ShootHit(RaycastHit raycastHit)
        {
            if (!CheckShooting()) return;
            Debug.Log("Shot.");
            
            var damageRecipient = raycastHit.collider.GetComponent<IDamageRecipient>();
            if (damageRecipient != null)
            {
                damageRecipient.Hit(_damage);
                _crosshairChangerOnHit.Change();
            }
            
            HitEffect(raycastHit.point, Quaternion.LookRotation(raycastHit.normal));
            ShootEffect();
        }

        private void ShootMissed()
        {
            if (!CheckShooting()) return;
            Debug.Log("Shot.");
            
            ShootEffect();
        }

        private bool CheckShooting()
        {
            var isShooting = Time.time > _nextFire;
            if(isShooting) _nextFire = Time.time + _timeBetweenShots;
            return isShooting;
        }

        private void HitEffect(Vector3 position, Quaternion rotation)
        {
            _hitEffect?.Show(position, rotation);
        }

        private void ShootEffect()
        {
            _shootEffect?.Show();
            _weaponShootAnimation?.Run();
        }

        private void OnDestroy()
        {
            _playerShootingSystem.EventShootHit -= ShootHit;
            _playerShootingSystem.EventShootMissed -= ShootMissed;
        }
    }
}