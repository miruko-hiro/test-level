
using UnityEditor;
#if UNITY_EDITOR
#endif

namespace Game.Helpers.Scripts
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