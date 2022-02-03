using UnityEngine;

namespace Game.Scripts.GameMechanics.Weapons
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