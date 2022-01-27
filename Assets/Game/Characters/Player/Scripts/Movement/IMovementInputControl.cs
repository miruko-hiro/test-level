namespace Game.Characters.Player.Scripts.Movement
{
    public interface IMovementInputControl
    {
        public (float, float) CurrentInput();
    }
}