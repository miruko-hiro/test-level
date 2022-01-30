using System;
using Game.Player.Scripts.Gazing;
using Game.Scripts;
using Game.Weapons.Crosshairs.Scripts;
using UnityEngine;

namespace Game.Weapons.Scripts
{
    public class WeaponCrosshair : MonoBehaviour
    {
        [SerializeField] private PlayerGazingSystem _playerGazingSystem;

        private ICrosshairChanger _crosshairChangerOnPoint;

        private void Awake()
        {
            _crosshairChangerOnPoint = GetComponentInChildren<CrosshairChangerOnPoint>();
            _playerGazingSystem.EventHitIntoSomething += ChangeCrosshairToEnemy;
            _playerGazingSystem.EventHitIntoNothing += ChangeCrosshairToDefault;
        }

        private void ChangeCrosshairToEnemy(RaycastHit hit)
        {
            if (hit.transform.GetComponent<IDamageRecipient>() != null)
                _crosshairChangerOnPoint.Change();
            else
                _crosshairChangerOnPoint.UndoChange();
        }

        private void ChangeCrosshairToDefault()
        {
            _crosshairChangerOnPoint.UndoChange();
        }

        private void OnDestroy()
        {
            _playerGazingSystem.EventHitIntoSomething -= ChangeCrosshairToEnemy;
            _playerGazingSystem.EventHitIntoNothing -= ChangeCrosshairToDefault;
        }
    }
}