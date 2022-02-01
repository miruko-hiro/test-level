using System;
using UnityEngine;

namespace Game.Characters.Enemies.Scripts.Rotation
{
    public class EnemyRotationSystem: MonoBehaviour
    {
        [SerializeField] private float _smooth = 5f;
        private Transform _transform;
        private bool _isLockOntoTarget;
        private Transform _transformTarget;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        public void LockOntoTarget(Transform targetTransform)
        {
            _transformTarget = targetTransform;
            _isLockOntoTarget = true;
        }

        public void TakeOffTarget()
        {
            _isLockOntoTarget = false;
        }

        private void ChangeRotation()
        {
            if (_isLockOntoTarget)
            {
                var direction = _transformTarget.position - transform.position;
                direction.y = 0f;
                _transform.rotation = Quaternion.Slerp(_transform.rotation, Quaternion.LookRotation(direction),  Time.deltaTime * _smooth);
            }
        }

        private void Update()
        {
            ChangeRotation();
        }
    }
}