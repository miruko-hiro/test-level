using System;
using UnityEngine;

namespace Game.Scripts
{
    public class CollisionDamage : MonoBehaviour
    {
        [SerializeField] private GameObject _objectTakingDamage;
        [SerializeField][Min(0)] private int _damageMultiplier = 1;
        private IDamageRecipient _damageRecipient;

        private void Awake()
        {
            _damageRecipient = _objectTakingDamage.GetComponent<IDamageRecipient>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.CompareTag("Damage"))
            {
                var damage = other.collider.GetComponent<IDamage>().AmountOfDamage;
                _damageRecipient.Hit(damage * _damageMultiplier);
            }
        }
    }
}