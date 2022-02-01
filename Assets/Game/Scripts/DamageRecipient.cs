using System;
using UnityEngine;

namespace Game.Scripts
{
    public class DamageRecipient: MonoBehaviour, IDamageRecipient
    {
        public event Action<int> EventHit;

        [SerializeField] private int _damageMultiplier = 1;

        public void Hit(int damage)
        {
            EventHit?.Invoke(damage * _damageMultiplier);
        }
    }
}