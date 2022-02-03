using UnityEngine;

namespace Game.Scripts.GameMechanics.Weapons
{
    public class WeaponShootAnimation :IWeaponShootAnimation
    {
        private readonly Animator _animator;
        private static readonly int Shoot = Animator.StringToHash("Shoot");

        public WeaponShootAnimation(Animator animator)
        {
            _animator = animator;
        }

        public void Run()
        {
            _animator.Rebind();
            _animator.SetTrigger(Shoot);
        }
    }
}