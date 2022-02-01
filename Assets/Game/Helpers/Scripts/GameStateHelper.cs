using UnityEngine;

namespace Game.Helpers.Scripts
{
    public class GameStateHelper
    {
        public void Pause()
        {
            Time.timeScale = 0;
        }

        public void Play()
        {
            Time.timeScale = 1;
        }
    }
}