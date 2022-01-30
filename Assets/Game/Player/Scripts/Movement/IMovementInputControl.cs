namespace Game.Player.Scripts.Movement
{
    public interface IMovementInputControl
    {
        public (float, float) CurrentInput();
    }
}