using System;
using Game.Scripts.GameMechanics.Player;
using UnityEngine;

namespace Game.Scripts.GameMechanics.Core
{
    public class LossChecker: MonoBehaviour
    {
        public event Action EventLosingPositionReached;
        
        [SerializeField] private PlayerTarget _playerTarget;
        [SerializeField] private float _losingPositionY;

        private Transform _transformPlayer;

        private void Awake()
        {
            _transformPlayer = _playerTarget.GetComponent<Transform>();
        }

        private void FixedUpdate()
        {
            if (_transformPlayer.position.y < _losingPositionY)
            {
                EventLosingPositionReached?.Invoke();
            }
        }
    }
}