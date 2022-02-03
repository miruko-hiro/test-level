using UnityEngine;

namespace Game.Scripts.GameMechanics.Characters.Enemies.Movement
{
    public class EnemyMovementAnimation: IAnimation
    {
        private Animator _animator;
        private static readonly int Move = Animator.StringToHash("Move");

        public float AnimationTime => 1.1f;

        public EnemyMovementAnimation(Animator animator)
        {
            _animator = animator;
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