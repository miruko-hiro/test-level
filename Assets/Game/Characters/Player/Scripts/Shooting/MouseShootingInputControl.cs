﻿using UnityEngine;

namespace Game.Characters.Player.Scripts.Shooting
{
    public class MouseShootingInputControl: IShootingInputControl
    {
        public bool CurrentInput()
        {
            return Input.GetButton("Fire1");
        }
    }
}