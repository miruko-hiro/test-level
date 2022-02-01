using UnityEngine;

namespace Game.Characters.Enemies.Scripts.Movement
{
    public class EnemyMovementAnimation: MonoBehaviour, IAnimation
    {
        private Animator _animator;
        private static readonly int Move = Animator.StringToHash("Move");

        public float AnimationTime => 1.1f;

        public void Initialize()
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