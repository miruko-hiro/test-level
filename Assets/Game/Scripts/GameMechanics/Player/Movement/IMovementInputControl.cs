namespace Game.Scripts.GameMechanics.Player.Movement
{
    public interface IMovementInputControl
    {
        public (float, float) CurrentInput();
    }
}