using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Menu.Game.Message
{
    public class MessagePanel : MonoBehaviour, IMessagePanel
    {
        public event Action EventShowWinMessage;
        public event Action EventShowLossMessage;
        
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _textMesh;

        private MessagePanelPresenter _presenter;

        public Color ImageColor
        {
            get => _image.color;
            set => _image.color = value;
        }

        public string Text
        {
            get => _textMesh.text;
            set => _textMesh.text = value;
        }

        private void Awake()
        {
            _presenter = new MessagePanelPresenter(this);
        }

        public void ShowWinMessage()
        {
            EventShowWinMessage?.Invoke();
        }
        
        public void ShowLossMessage()
        {
            EventShowLossMessage?.Invoke();
        }

        private void OnDestroy()
        {
            _presenter = null;
        }
    }
}