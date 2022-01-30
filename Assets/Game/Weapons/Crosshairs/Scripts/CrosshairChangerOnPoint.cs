﻿using UnityEngine;
using UnityEngine.UI;

namespace Game.Weapons.Crosshairs.Scripts
{
    public class CrosshairChangerOnPoint: MonoBehaviour, ICrosshairChanger
    {
        [SerializeField] private Image _crosshair;
        [SerializeField] private Color _defaultColor;
        [SerializeField] private Color _enemyColor;

        public void Change()
        {
            _crosshair.color = _enemyColor;
        }

        public void UndoChange()
        {
            _crosshair.color = _defaultColor;
        }
    }
}