using System;
using UnityEngine;

namespace Game.Scripts.GameMechanics.Weapons
{
    public interface IWeaponShooter
    {
        public event Action EventDealingDamage;
        public void ShootHit(RaycastHit raycastHit);
    }
}