using System;
using Game.Scripts;
using UnityEngine;

namespace Game.Characters.Scripts
{
    public class Health : MonoBehaviour, IDamageRecipient
    {
        public event Action EventDeath;
        
        [SerializeField][Min(1)] private int _amountOfHealth = 1;

        public void Hit(int damage)
        {
            _amountOfHealth -= damage;
            if(_amountOfHealth <= 0) EventDeath?.Invoke();
        }
    }
}
