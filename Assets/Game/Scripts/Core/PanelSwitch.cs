using Game.UI.FirstPerson.Scripts;
using Game.UI.Menu.Scripts;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class PanelSwitch : MonoBehaviour
    {
        [SerializeField] private FirstPersonPanel _firstPersonPanel;
        [SerializeField] private GameMenuPanel _gameMenuPanel;
        [SerializeField] private MessagePanel _messagePanel;

        public void FirstPersonSwitch()
        {
            _gameMenuPanel.gameObject.SetActive(false);
            _firstPersonPanel.gameObject.SetActive(true);
        }

        public void GameMenuSwitch()
        {
            _firstPersonPanel.gameObject.SetActive(false);
            _gameMenuPanel.gameObject.SetActive(true);
        }

        public void ShowLossMessage()
        {
            _messagePanel.ShowLossMessage();
        }

        public void ShowWinMessage()
        {
            _messagePanel.ShowWinMessage();
        }
    }
}