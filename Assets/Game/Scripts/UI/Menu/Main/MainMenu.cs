using System;
using UnityEngine;

namespace Game.Scripts.UI.Menu.Main
{
    public class MainMenu : MonoBehaviour
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
