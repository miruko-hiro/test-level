using System;
using Game.Scripts;
using UnityEngine;

namespace Game.Characters.Scripts
{
    public class Health : MonoBehaviour, IHealth
    {
        public event Action EventDeath;
        
        [SerializeField][Min(1)] private int _amountOfHealth = 1;

        private void Awake()
        {
            var damageRecipients = GetComponentsInChildren<IDamageRecipient>();
            foreach (var damageRecipient in damageRecipients)
            {
                damageRecipient.EventHit += Hit;
            }
        }

        private void Hit(int damage)
        {
            Debug.Log("_amountOfHealth " + _amountOfHealth + " damage " + damage);
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
