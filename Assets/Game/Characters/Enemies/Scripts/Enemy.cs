using System;
using System.Collections;
using Game.Scripts;
using UnityEngine;

namespace Game.Characters.Enemies.Scripts
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _timeOfDeath = 1f;
        
        private IDamageRecipient _damageRecipient;
        private Animator _animator;
        private static readonly int DeathAnimation = Animator.StringToHash("Death");

        private void Awake()
        {
            _damageRecipient = GetComponent<IDamageRecipient>();
            _damageRecipient.EventDeath += Death;

            _animator = GetComponent<Animator>();
        }

        private void Death()
        {
            _animator.SetTrigger(DeathAnimation);
            Destroy(gameObject, _timeOfDeath);
        }

        private void OnDestroy()
        {
            _damageRecipient.EventDeath -= Death;
        }
    }
}
