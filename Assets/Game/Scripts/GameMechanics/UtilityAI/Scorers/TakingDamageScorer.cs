using Game.Scripts.GameMechanics.Characters;
using UnityEngine;

namespace Game.Scripts.GameMechanics.UtilityAI.Scorers
{
    public class TakingDamageScorer: BaseScorer
    {
        [SerializeField] private float _score;

        private bool _isHit;

        private void OnEnable()
        {
            var damageRecipients = GetComponentsInChildren<IDamageRecipient>();
            foreach (var damageRecipient in damageRecipients)
            {
                damageRecipient.EventHit += TakeDamage;
            }
        }

        private void TakeDamage(int damage)
        {
            if (damage > 0)
            {
                _isHit = true;
                OnClose();
            }
        }

        private void OnClose()
        {
            var damageRecipients = GetComponentsInChildren<IDamageRecipient>();
            foreach (var damageRecipient in damageRecipients)
            {
                damageRecipient.EventHit -= TakeDamage;
            }
        }

        public override float GetScore()
        {
            return _isHit ? _score : 0f;
        }

        private void OnDestroy()
        {
            OnClose();
        }
    }
}