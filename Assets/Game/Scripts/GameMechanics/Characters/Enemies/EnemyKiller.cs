using System.Collections;
using Game.Scripts.GameMechanics.Characters.Enemies.Movement;
using UnityEngine;

namespace Game.Scripts.GameMechanics.Characters.Enemies
{
    public class EnemyKiller : MonoBehaviour
    {
        
        [SerializeField] private ParticleSystem _deathEffectParticle;
        [SerializeField] private float _timeOfDeath = 1f;

        private IMovementStopper _movementStopper;
        private IHealth _health;
        private Animator _animator;
        private static readonly int DeathAnimation = Animator.StringToHash("Death");

        private void Awake()
        {
            OnOpen();
        }

        private void OnOpen()
        {
            _movementStopper = GetComponent<EnemyMovementSystem>();
            _health = GetComponent<Health>();
            _animator = GetComponent<Animator>();
            _health.EventDeath += Death;
        }

        private void OnClose()
        {
            _health.EventDeath -= Death;
        }

        private void Death()
        {
            StartCoroutine(DeathCoroutine());
        }

        private IEnumerator DeathCoroutine()
        {
            _movementStopper?.Stop();
            _animator.SetTrigger(DeathAnimation);
            yield return new WaitForSeconds(_timeOfDeath);
            _deathEffectParticle.transform.position = transform.position;
            _deathEffectParticle.Play();
            yield return new WaitForSeconds(0.2f);
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            OnClose();
        }
    }
}
