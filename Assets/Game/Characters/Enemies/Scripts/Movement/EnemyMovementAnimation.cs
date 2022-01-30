﻿using UnityEngine;

namespace Game.Characters.Enemies.Scripts.Movement
{
    public class EnemyMovementAnimation: MonoBehaviour, IMovementAnimation
    {
        private Animator _animator;
        private static readonly int Move = Animator.StringToHash("Move");
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        
        public void Run()
        {
            _animator.SetBool(Move, true);
        }

        public void Stop()
        {
            _animator.SetBool(Move, false);
        }
    }
}