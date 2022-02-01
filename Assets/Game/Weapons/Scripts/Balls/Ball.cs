using System;
using Game.Player.Scripts;
using Game.Scripts;
using UnityEngine;

namespace Game.Weapons.Scripts.Balls
{
    public class Ball : MonoBehaviour, IBall
    {
        [SerializeField] private float _force = 10f;
        [SerializeField] private float _radiusExplosion = 2f;
        private Transform _transform;
        private Rigidbody _rigidbody;
        private IHealth _health;

        public bool IsEnable { get; private set; }
        public Vector3 Position => _transform.position;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _rigidbody = GetComponent<Rigidbody>();
            _health = GetComponent<Health>();
            _health.EventDeath += Death;
        }

        private void OnEnable()
        {
            IsEnable = true; 
        }

        public void ThrowWithForce(Vector3 startPosition, Vector3 force)
        {
            _rigidbody.velocity = Vector3.zero;
            _transform.position = startPosition;
            _rigidbody.velocity = force;
        }

        public void Explosion(int layerIndexes)
        {
            var colliders = Physics.OverlapSphere(_transform.position, _radiusExplosion, layerIndexes);
            if(colliders.Length > 0)
            {
                foreach (var colliderObj in colliders)
                {
                    var target = colliderObj.transform.GetComponent<ITarget>();
                    target?.AddExplosionForce(_force, _transform.position, _radiusExplosion, 3.0f);
                }
            }
            gameObject.SetActive(false);
        }

        private void Death()
        {
            IsEnable = false;
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            _health.EventDeath -= Death;
        }
    }
}