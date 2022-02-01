using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Menu.Scripts
{
    public class MessagePanel : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _textMesh;
        
        private readonly Color _colorWinMessage = new Color(96f, 250f, 167f, 255f);
        private readonly Color _colorLossMessage = new Color(255f, 0f, 0f, 255f);
        private readonly string _textWin = "You Won";
        private readonly string _textLoss = "You Lose";

        public void ShowWinMessage()
        {
            _image.color = _colorWinMessage;
            _textMesh.text = _textWin;
        }
        
        public void ShowLossMessage()
        {
            _image.color = _colorLossMessage;
            _textMesh.text = _textLoss;
        }
    }
}