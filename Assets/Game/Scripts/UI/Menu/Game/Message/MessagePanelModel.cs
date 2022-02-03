using UnityEngine;

namespace Game.Scripts.UI.Menu.Game.Message
{
    public class MessagePanelModel
    {
        private readonly Color _colorWinMessage;
        private readonly Color _colorLossMessage;
        private readonly string _textWin;
        private readonly string _textLoss;

        public Color ColorWinMessage => _colorWinMessage;
        public Color ColorLossMessage => _colorLossMessage;
        public string TextWin => _textWin;
        public string TextLoss => _textLoss;

        public MessagePanelModel()
        {
            _colorWinMessage = new Color(96f, 250f, 167f, 255f);
            _colorLossMessage = new Color(255f, 0f, 0f, 255f);
            _textWin = "You Won";
            _textLoss = "You Lose";
        }
    }
}