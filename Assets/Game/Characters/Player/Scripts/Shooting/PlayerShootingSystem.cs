using Game.Characters.Scripts;
using Game.Weapons.Scripts;
using UnityEngine;

namespace Game.Characters.Player.Scripts.Shooting
{
    public class PlayerShootingSystem : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Weapon _weapon;
        
        private IShootingInputControl _shootingInputControl;

        private void Awake()
        {
            _shootingInputControl = new MouseShootingInputControl();
        }

        private void Update()
        {
            Shoot();
        }

        private void Shoot()
        {
            if (_shootingInputControl.CurrentInput() && _weapon.CanShoot()) 
            {
                var rayOrigin = _mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

                _weapon.Shoot(rayOrigin, _mainCamera.transform.forward);
            }
        }
    }
}