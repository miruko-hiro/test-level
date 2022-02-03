using System;
using UnityEngine;

namespace Game.Scripts.UI.Menu.Game
{
    public class GameMenu: MonoBehaviour
    {
        public event Action EventPlayGame;
        public event Action EventExitGame;
        
        public void OnPlay()
        {
            EventPlayGame?.Invoke();
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