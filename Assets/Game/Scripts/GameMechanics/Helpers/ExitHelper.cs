
#if UNITY_EDITOR
using UnityEditor;
#else
using UnityEngine;
#endif

namespace Game.Scripts.GameMechanics.Helpers
{
    public class ExitHelper
    {
        public void Exit()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
    }
}