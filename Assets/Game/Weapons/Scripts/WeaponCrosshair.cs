using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Weapons.Scripts
{
    public class WeaponCrosshair : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Image _crosshair;
        [SerializeField] private Color _default;
        [SerializeField] private Color _enemy;
        [SerializeField][Min(1f)] private float _weaponRange = 500f;
        
        private int _enemyLayerIndex;

        private void Awake()
        {
            _enemyLayerIndex = LayerMask.GetMask("Enemy");
        }

        private void Update()
        {
            if (Check()) ChangeColorToEnemy();
            else ChangeColorToDefault();
        }

        private bool Check()
        {
            var rayOrigin = _mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            return Physics.Raycast(rayOrigin, _mainCamera.transform.forward, _weaponRange, _enemyLayerIndex);
        }

        private void ChangeColorToEnemy()
        {
            if (_crosshair.color != _enemy)
            {
                _crosshair.color = _enemy;
            }
        }

        private void ChangeColorToDefault()
        {
            if (_crosshair.color != _default)
            {
                _crosshair.color = _default;
            }
        }
    }
}