using UnityEngine;

namespace Game.Characters.Enemies.Scripts.Shooting
{
    public class EnemyShootingAnimation : MonoBehaviour, IAnimation
    {
        private Animator _animator;
        private static readonly int Shoot = Animator.StringToHash("Shoot");

        public float AnimationTime => 0.8f;

        public void Initialize()
        {
            _animator = GetComponent<Animator>();
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