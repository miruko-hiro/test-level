using System;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class MenuCallChecker: MonoBehaviour
    {
        public event Action EventCall;
        
        private IMenuInputControl _menuInputControl;

        private void Awake()
        {
            _menuInputControl = new KeyboardMenuInputControl();
        }

        private void Update()
        {
            MenuCall();
        }

        private void MenuCall()
        {
            if (_menuInputControl.CurrentInput())
            {
                EventCall?.Invoke();
            }
        }
    }
}