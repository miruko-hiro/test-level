using System;
using UnityEngine;

namespace Game.Weapons.Scripts
{
    public class WeaponAnimation : MonoBehaviour, IWeaponAnimation
    {
        private Animator _animator;
        private static readonly int Shoot = Animator.StringToHash("Shoot");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void ShootAnimation()
        {
            _animator.Rebind();
            _animator.SetTrigger(Shoot);
        }
    }
}