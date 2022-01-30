using System;
using UnityEngine;

namespace Game.Weapons.Scripts
{
    public class WeaponShootAnimation : MonoBehaviour, IWeaponShootAnimation
    {
        private Animator _animator;
        private static readonly int Shoot = Animator.StringToHash("Shoot");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Run()
        {
            _animator.Rebind();
            _animator.SetTrigger(Shoot);
        }
    }
}