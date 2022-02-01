using System;
using UnityEngine;

namespace Game.UI.Menu.Scripts
{
    public class GameMenu: MonoBehaviour
    {
        public event Action EventContinueGame;
        public event Action EventExitGame;
        
        public void OnContinue()
        {
            EventContinueGame?.Invoke();
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