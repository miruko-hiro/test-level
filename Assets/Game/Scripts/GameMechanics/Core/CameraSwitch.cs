using Game.Scripts.GameMechanics.Cameras;
using Game.Scripts.UI.FirstPerson;
using Game.Scripts.UI.Menu.Main;
using UnityEngine;

namespace Game.Scripts.GameMechanics.Core
{
    public class CameraSwitch : MonoBehaviour
    {
        [Header("Menu Camera")]
        [SerializeField] private MenuCamera _menuCamera;
        [SerializeField] private MainMenuPanel _mainMenuPanel;
        
        [Header("First Person Camera")]
        [SerializeField] private FirstPersonCamera _firstPersonCamera;
        [SerializeField] private FirstPersonPanel _firstPersonPanel;

        public void SwitchToFirstPerson()
        {
            _menuCamera.gameObject.SetActive(false);
            _mainMenuPanel.gameObject.SetActive(false);
            
            _firstPersonCamera.gameObject.SetActive(true);
            _firstPersonPanel.gameObject.SetActive(true);
        }
        
        public void SwitchToMenu()
        {
            _firstPersonCamera.gameObject.SetActive(false);
            _firstPersonPanel.gameObject.SetActive(false);
            
            _menuCamera.gameObject.SetActive(true);
            _mainMenuPanel.gameObject.SetActive(true);
        }
    }
}