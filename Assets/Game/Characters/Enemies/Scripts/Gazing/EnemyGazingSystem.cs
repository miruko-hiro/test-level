using System;
using UnityEngine;

namespace Game.Characters.Enemies.Scripts.Gazing
{
    public class EnemyGazingSystem : MonoBehaviour
    {
        private Transform _transform;
        private int _playerLayerIndex;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _playerLayerIndex = LayerMask.GetMask("Player");
        }

        public bool CheckIfTargetIsVisible(Vector3 targetPosition)
        {
            var originPosition = _transform.position;
            var direction = targetPosition - originPosition;
            return Physics.Raycast(originPosition, direction, Mathf.Infinity, _playerLayerIndex);
        }
    }
}