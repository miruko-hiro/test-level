using Game.Scripts.GameMechanics.Characters;
using Game.Scripts.GameMechanics.Player.Shooting;
using Game.Scripts.GameMechanics.Weapons.Crosshairs;
using UnityEngine;

namespace Game.Scripts.GameMechanics.Weapons
{
    [RequireComponent(typeof(WeaponShootEffect),
        typeof(CrosshairChangerOnHit))]
    public class WeaponManager : MonoBehaviour
    {
        [SerializeField] private PlayerShootingSystem _playerShootingSystem;
        [SerializeField][Min(0f)] private float _timeBetweenShots = 2f;
        [SerializeField][Min(0)] private int _damage = 1;

        private IHitEffect _hitEffect;
        private IShootEffect _shootEffect;
        private IWeaponShootAnimation _weaponShootAnimation;
        private ICrosshairChanger _crosshairChangerOnHit;
        private IWeaponShooter _weaponShooter;
        private float _nextFire;
        
        private void Awake()
        {
            OnOpen();
        }

        private void OnOpen()
        {
            _weaponShooter = new WeaponShooter(_damage);
            _hitEffect = new WeaponHitEffect();
            _shootEffect = GetComponent<WeaponShootEffect>();
            _weaponShootAnimation = new WeaponShootAnimation(GetComponent<Animator>());
            _crosshairChangerOnHit = GetComponent<CrosshairChangerOnHit>();
            _playerShootingSystem.EventShootHit += ShootHit;
            _playerShootingSystem.EventShootMissed += ShootMissed;
            _weaponShooter.EventDealingDamage += CrosshairChange;
        }

        private void OnClose()
        {
            _playerShootingSystem.EventShootHit -= ShootHit;
            _playerShootingSystem.EventShootMissed -= ShootMissed;
            _weaponShooter.EventDealingDamage -= CrosshairChange;
        }

        private void ShootHit(RaycastHit raycastHit)
        {
            if (!CheckShooting()) return;
            Debug.Log("Shot.");
            
            _weaponShooter.ShootHit(raycastHit);
            
            HitEffect(raycastHit.point, Quaternion.LookRotation(raycastHit.normal));
            ShootEffect();
        }

        private void CrosshairChange()
        {
            _crosshairChangerOnHit.Change();
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

        private void ShootMissed()
        {
            if (!CheckShooting()) return;
            Debug.Log("Shot.");
            
            ShootEffect();
        }

        private void OnDestroy()
        {
            OnClose();
        }
    }
}