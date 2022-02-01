using Game.UI.Menu.Scripts;
using UnityEngine;

namespace Game.Scripts.Core
{
    [RequireComponent(typeof(GameState), 
        typeof(CameraSwitch), 
        typeof(LossChecker))]
    [RequireComponent(typeof(GameRestarter), 
        typeof(PanelSwitch))]
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private MainMenu _mainMenu;
        [SerializeField] private GameMenu _gameMenu;
        [SerializeField] private FinishTrigger _finishTrigger;

        private GameState _gameState;
        private CameraSwitch _cameraSwitch;
        private LossChecker _lossChecker;
        private GameRestarter _gameRestarter;
        private PanelSwitch _panelSwitch;

        private void Awake()
        {
            Initialize();
            OnOpen();
        }

        private void Initialize()
        {
            _gameState = GetComponent<GameState>();
            _cameraSwitch = GetComponent<CameraSwitch>();
            _lossChecker = GetComponent<LossChecker>();
            _gameRestarter = GetComponent<GameRestarter>();
            _panelSwitch = GetComponent<PanelSwitch>();
        }

        private void OnOpen()
        {
            _mainMenu.EventPlayGame += PlayGame;
            _mainMenu.EventExitGame += ExitGame;

            _gameMenu.EventContinueGame += ContinueGame;
            _gameMenu.EventExitGame += ExitGame;

            _lossChecker.EventLosingPositionReached += ReachedLoss;

            _finishTrigger.EventReachedFinish += ReachedFinish;
        }

        private void OnClose()
        {
            _mainMenu.EventPlayGame -= PlayGame;
            _mainMenu.EventExitGame -= ExitGame;

            _gameMenu.EventContinueGame -= ContinueGame;
            _gameMenu.EventExitGame -= ExitGame;

            _lossChecker.EventLosingPositionReached -= ReachedLoss;

            _finishTrigger.EventReachedFinish -= ReachedFinish;
        }

        private void PlayGame()
        {
            _cameraSwitch.SwitchToFirstPerson();
            _gameState.PlayGame();
        }

        private void ContinueGame()
        {
            _panelSwitch.FirstPersonSwitch();
            _gameRestarter.Restart();
            _gameState.PlayGame();
        }

        private void PauseGame()
        {
            _panelSwitch.GameMenuSwitch();
            _gameState.PauseGame();
        }

        private void ExitGame()
        {
            _gameState.ExitGame();
        }

        private void ReachedFinish()
        {
            _panelSwitch.ShowWinMessage();
            PauseGame();
        }

        private void ReachedLoss()
        {
            _panelSwitch.ShowLossMessage();
            PauseGame();
        }

        private void OnDestroy()
        {
            OnClose();
        }
    }
}