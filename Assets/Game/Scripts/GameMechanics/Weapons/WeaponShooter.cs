using System;
using Game.Scripts.GameMechanics.Characters;
using UnityEngine;

namespace Game.Scripts.GameMechanics.Weapons
{
    public class WeaponShooter: IWeaponShooter
    {
        public event Action EventDealingDamage;

        private readonly int _damage;

        public WeaponShooter(int damage)
        {
            _damage = damage;
        }

        public void ShootHit(RaycastHit raycastHit)
        {
            
            var damageRecipient = raycastHit.collider.GetComponent<IDamageRecipient>();
            if (damageRecipient != null)
            {
                damageRecipient.Hit(_damage);
                EventDealingDamage?.Invoke();
            }
        }
    }
}