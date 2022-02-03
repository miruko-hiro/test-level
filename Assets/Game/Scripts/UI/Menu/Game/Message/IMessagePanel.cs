using System;
using UnityEngine;

namespace Game.Scripts.UI.Menu.Game.Message
{
    public interface IMessagePanel
    {
        public event Action EventShowWinMessage;
        public event Action EventShowLossMessage;
        
        public Color ImageColor { get; set; }
        public string Text { get; set; }
    }
}