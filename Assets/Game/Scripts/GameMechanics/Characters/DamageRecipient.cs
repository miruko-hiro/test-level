using System;
using UnityEngine;

namespace Game.Scripts.GameMechanics.Characters
{
    public class DamageRecipient: MonoBehaviour, IDamageRecipient
    {
        public event Action<int> EventHit;

        [SerializeField] private int _damageMultiplier = 1;

        public void Hit(int damage)
        {
            Debug.Log("Hitting an agent.");
            EventHit?.Invoke(damage * _damageMultiplier);
        }
    }
}