using System;
using UnityEngine;

namespace Game.Scripts.GameMechanics.Characters
{
    public class Health : MonoBehaviour, IHealth
    {
        public event Action EventDeath;
        
        [SerializeField][Min(1)] private int _maxHealth = 1;
        private int _amountOfHealth;
        
        private void Awake()
        {
            var damageRecipients = GetComponentsInChildren<IDamageRecipient>();
            foreach (var damageRecipient in damageRecipients)
            {
                damageRecipient.EventHit += Hit;
            }
        }

        private void OnEnable()
        {
            _amountOfHealth = _maxHealth;
        }

        private void Hit(int damage)
        {
            _amountOfHealth -= damage;
            if(_amountOfHealth <= 0) EventDeath?.Invoke();
        }

        private void OnDestroy()
        {
            var damageRecipients = GetComponentsInChildren<IDamageRecipient>();
            foreach (var damageRecipient in damageRecipients)
            {
                damageRecipient.EventHit -= Hit;
            }
        }
    }
}
