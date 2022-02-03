using System;
using Game.Scripts.GameMechanics.Player.Gazing;
using UnityEngine;

namespace Game.Scripts.GameMechanics.Player.Shooting
{
    [RequireComponent(typeof(PlayerGazingSystem))]
    public class PlayerShootingSystem : MonoBehaviour
    {
        public event Action<RaycastHit> EventShootHit;
        public event Action EventShootMissed;
            
        private PlayerGazingSystem _playerGazingSystem;
        private IShootingInputControl _shootingInputControl;

        private void Awake()
        {
            OnOpen();
        }

        private void OnOpen()
        {
            _shootingInputControl = new MouseShootingInputControl();
            _playerGazingSystem = GetComponent<PlayerGazingSystem>();
            _playerGazingSystem.EventHitIntoSomething += ShootHit;
            _playerGazingSystem.EventHitIntoNothing += ShootMissed;
        }

        private void OnClose()
        {
            _playerGazingSystem.EventHitIntoSomething -= ShootHit;
            _playerGazingSystem.EventHitIntoNothing -= ShootMissed;
        }

        private void ShootHit(RaycastHit raycastHit)
        {
            if (_shootingInputControl.CurrentInput())
            {
                EventShootHit?.Invoke(raycastHit);
            }
        }

        private void ShootMissed()
        {
            if (_shootingInputControl.CurrentInput())
            {
                EventShootMissed?.Invoke();
            }
        }

        private void OnDestroy()
        {
            OnClose();
        }
    }
}