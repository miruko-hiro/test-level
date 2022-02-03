using UnityEngine;

namespace Game.Scripts.GameMechanics.Characters.Enemies.Shooting
{
    public class EnemyShootingAnimation : IAnimation
    {
        private Animator _animator;
        private static readonly int Shoot = Animator.StringToHash("Shoot");

        public float AnimationTime => 0.8f;

        public EnemyShootingAnimation(Animator animator)
        {
            _animator = animator;
        }

        public void Run()
        {
            _animator.SetTrigger(Shoot);
        }

        public void Stop()
        {
            _animator.Rebind();
        }
    }
}