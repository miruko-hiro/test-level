using System;
using Game.Helpers.Scripts;
using UnityEngine;

namespace Game.Weapons.Scripts
{
    public class WeaponHitEffect: MonoBehaviour, IHitEffect
    {
        [SerializeField] private Transform _bulletContainer;

        private PoolMono<Bullet> _bulletPool;

        private void Awake()
        {
            var bullet = Resources.Load<Bullet>("Bullet");
            _bulletPool = new PoolMono<Bullet>(bullet, 2, _bulletContainer);
        }

        public void Show(Vector3 position, Quaternion rotation)
        {
            var bullet = _bulletPool.GetFreeElement();
            bullet.Explode(position, rotation);
        }
    }
}