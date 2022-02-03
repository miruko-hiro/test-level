using System;
using UnityEngine;

namespace Game.Scripts.UI.Menu.Pause
{
    public class PauseMenu : MonoBehaviour
    {
        public event Action EventContinueGame;
        public event Action EventNewGame;
        public event Action EventExitGame;
        
        public void OnContinue()
        {
            EventContinueGame?.Invoke();
        }

        public void OnNewGame()
        {
            EventNewGame?.Invoke();
        }

        public void OnSettings()
        {
            
        }

        public void OnExit()
        {
            EventExitGame?.Invoke();
        }
    }
}