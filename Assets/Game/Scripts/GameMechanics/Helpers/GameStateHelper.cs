﻿using UnityEngine;

namespace Game.Scripts.GameMechanics.Helpers
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