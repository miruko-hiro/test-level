namespace Game.Scripts.UI.Menu.Game.Message
{
    public class MessagePanelPresenter
    {
        private readonly MessagePanelModel _model;
        private readonly IMessagePanel _view;

        public MessagePanelPresenter(IMessagePanel view)
        {
            _view = view;
            _model = new MessagePanelModel();

            OnOpen();
        }

        private void OnOpen()
        {
            _view.EventShowWinMessage += ShowWinMessage;
            _view.EventShowLossMessage += ShowLossMessage;
        }

        private void OnClose()
        {
            _view.EventShowWinMessage -= ShowWinMessage;
            _view.EventShowLossMessage -= ShowLossMessage;
        }

        private void ShowWinMessage()
        {
            _view.ImageColor = _model.ColorWinMessage;
            _view.Text = _model.TextWin;
        }

        private void ShowLossMessage()
        {
            _view.ImageColor = _model.ColorLossMessage;
            _view.Text = _model.TextLoss;
        }

        ~MessagePanelPresenter()
        {
            OnClose();
        }
    }
}