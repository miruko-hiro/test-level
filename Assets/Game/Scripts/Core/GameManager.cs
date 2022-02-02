using Game.UI.Menu.Scripts;
using UnityEngine;

namespace Game.Scripts.Core
{
    [RequireComponent(typeof(GameState), 
        typeof(CameraSwitch), 
        typeof(LossChecker))]
    [RequireComponent(typeof(GameRestarter), 
        typeof(PanelSwitch), 
        typeof(MenuCallChecker))]
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private MainMenu _mainMenu;
        [SerializeField] private GameMenu _gameMenu;
        [SerializeField] private PauseMenu _pauseMenu;
        [SerializeField] private FinishTrigger _finishTrigger;

        private GameState _gameState;
        private CameraSwitch _cameraSwitch;
        private LossChecker _lossChecker;
        private GameRestarter _gameRestarter;
        private PanelSwitch _panelSwitch;
        private MenuCallChecker _menuCallChecker;
        private GameSessionLog _gameSession;
        private bool _isPause;

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
            _menuCallChecker = GetComponent<MenuCallChecker>();
            _gameSession = new GameSessionLog();
        }

        private void OnOpen()
        {
            _mainMenu.EventPlayGame += PlayGame;
            _mainMenu.EventExitGame += ExitGame;

            _gameMenu.EventPlayGame += RestartGame;
            _gameMenu.EventExitGame += ExitGame;

            _pauseMenu.EventContinueGame += ContinueGame;
            _pauseMenu.EventExitGame += ExitGame;

            _lossChecker.EventLosingPositionReached += ReachedLoss;

            _finishTrigger.EventReachedFinish += ReachedFinish;
        }

        private void OnClose()
        {
            _mainMenu.EventPlayGame -= PlayGame;
            _mainMenu.EventExitGame -= ExitGame;

            _gameMenu.EventPlayGame -= RestartGame;
            _gameMenu.EventExitGame -= ExitGame;

            _pauseMenu.EventContinueGame -= ContinueGame;
            _pauseMenu.EventExitGame -= ExitGame;

            _lossChecker.EventLosingPositionReached -= ReachedLoss;

            _finishTrigger.EventReachedFinish -= ReachedFinish;

            _menuCallChecker.EventCall -= PauseCallGame;
        }

        private void PlayGame()
        {
            _cameraSwitch.SwitchToFirstPerson();
            _gameState.PlayGame();
            Debug.Log("Game Start.");

            _menuCallChecker.EventCall += PauseCallGame;
        }

        private void RestartGame()
        {
            _panelSwitch.FirstPersonSwitch();
            _gameRestarter.Restart();
            _gameState.PlayGame();
            Debug.Log("Game Start.");
        }

        private void ContinueGame()
        {
            _panelSwitch.FirstPersonSwitch();
            _gameState.PlayGame();
        }

        private void PauseGame()
        {
            _panelSwitch.PauseMenuSwitch();
            _gameState.PauseGame();
        }

        private void PauseCallGame()
        {
            if (!_isPause)
            {
                PauseGame();
                _isPause = true;
            }
            else
            {
                ContinueGame();
                _isPause = false;
            }
        }

        private void ExitGame()
        {
            _gameState.ExitGame();
        }

        private void ReachedFinish()
        {
            _panelSwitch.GameMenuSwitch();
            _panelSwitch.ShowWinMessage();
            _gameState.PauseGame();
            Debug.Log("Winning.");
        }

        private void ReachedLoss()
        {
            _panelSwitch.GameMenuSwitch();
            _panelSwitch.ShowLossMessage();
            _gameState.PauseGame();
            Debug.Log("Losing.");
        }

        private void OnDestroy()
        {
            _gameSession = null;
            OnClose();
        }
    }
}