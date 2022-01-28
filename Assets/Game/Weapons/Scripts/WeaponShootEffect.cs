using UnityEngine;

namespace Game.Weapons.Scripts
{
    public class WeaponShootEffect: MonoBehaviour, IShootEffect
    {
        [SerializeField] private ParticleSystem _flashShoot;

        public void Show()
        {
            _flashShoot.Play();
        }
    }
}