using UnityEngine;

namespace Game.Weapons.Scripts
{
    public class WeaponShootEffect: MonoBehaviour, IShootEffect
    {
        [SerializeField] private ParticleSystem _flashShootParticle;

        public void Show()
        {
            _flashShootParticle.Play();
        }
    }
}