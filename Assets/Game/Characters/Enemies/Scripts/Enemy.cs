using System.Collections;
using Game.Characters.Scripts;
using UnityEngine;

namespace Game.Characters.Enemies.Scripts
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _deathEffectParticle;
        [SerializeField] private float _timeOfDeath = 1f;
        
        private IHealth _health;
        private Animator _animator;
        private static readonly int DeathAnimation = Animator.StringToHash("Death");

        private void Awake()
        {
            _health = GetComponent<Health>();
            _animator = GetComponent<Animator>();
            _health.EventDeath += Death;
        }

        private void Death()
        {
            _animator.SetTrigger(DeathAnimation);
            StartCoroutine(DeathCoroutine());
        }

        private IEnumerator DeathCoroutine()
        {
            yield return new WaitForSeconds(_timeOfDeath);
            _deathEffectParticle.transform.position = transform.position;
            _deathEffectParticle.Play();
            yield return new WaitForSeconds(0.2f);
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _health.EventDeath -= Death;
        }
    }
}
