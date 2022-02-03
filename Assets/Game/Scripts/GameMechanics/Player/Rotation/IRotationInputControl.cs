namespace Game.Scripts.GameMechanics.Player.Rotation
{
    public interface IRotationInputControl
    {
        public (float, float) CurrentInput();
    }
}