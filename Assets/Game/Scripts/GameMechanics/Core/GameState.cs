using Game.Scripts.GameMechanics.Helpers;
using Game.Scripts.GameMechanics.Player.Aiming;
using Game.Scripts.GameMechanics.Player.Gazing;
using Game.Scripts.GameMechanics.Player.Movement;
using Game.Scripts.GameMechanics.Player.Rotation;
using UnityEngine;

namespace Game.Scripts.GameMechanics.Core
{
    public class GameState : MonoBehaviour
    {
        [Header("Player Systems")]
        [SerializeField] private PlayerRotationSystem _playerRotationSystem;
        [SerializeField] private PlayerMovementSystem _playerMovementSystem;
        [SerializeField] private PlayerGazingSystem _playerGazingSystem;
        [SerializeField] private PlayerAimingSystem _playerAimingSystem;

        private CursorState _cursorState;
        
        private void Awake()
        {
            _cursorState = new CursorState();
            _cursorState.UnlockCursor();
        }

        public void PlayGame()
        {
            Time.timeScale = 1f;
            
            _playerRotationSystem.StateGame = StateGame.Play;
            _playerMovementSystem.StateGame = StateGame.Play;
            _playerGazingSystem.StateGame = StateGame.Play;
            _playerAimingSystem.StateGame = StateGame.Play;

            _cursorState.LockCursor();
        }

        public void PauseGame()
        {
            Time.timeScale = 0f;
            
            _playerRotationSystem.StateGame = StateGame.Pause;
            _playerMovementSystem.StateGame = StateGame.Pause;
            _playerGazingSystem.StateGame = StateGame.Pause;
            _playerAimingSystem.StateGame = StateGame.Pause;

            _cursorState.UnlockCursor();
        }

        public void ExitGame()
        {
            new ExitHelper().Exit();
        }
    }
}