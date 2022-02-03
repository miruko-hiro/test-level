using Game.Scripts.GameMechanics.Characters;
using Game.Scripts.GameMechanics.Player.Gazing;
using Game.Scripts.GameMechanics.Weapons.Crosshairs;
using UnityEngine;

namespace Game.Scripts.GameMechanics.Weapons
{
    [RequireComponent(typeof(CrosshairChangerOnPoint))]
    public class WeaponCrosshair : MonoBehaviour
    {
        [SerializeField] private PlayerGazingSystem _playerGazingSystem;

        private ICrosshairChanger _crosshairChangerOnPoint;

        private void Awake()
        {
            OnOpen();
        }

        private void OnOpen()
        {
            _crosshairChangerOnPoint = GetComponent<CrosshairChangerOnPoint>();
            _playerGazingSystem.EventHitIntoSomething += ChangeCrosshairToEnemy;
            _playerGazingSystem.EventHitIntoNothing += ChangeCrosshairToDefault;
        }

        private void OnClose()
        {
            _playerGazingSystem.EventHitIntoSomething -= ChangeCrosshairToEnemy;
            _playerGazingSystem.EventHitIntoNothing -= ChangeCrosshairToDefault;
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
            OnClose();
        }
    }
}