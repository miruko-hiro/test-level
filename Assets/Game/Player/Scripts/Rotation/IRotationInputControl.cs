namespace Game.Player.Scripts.Rotation
{
    public interface IRotationInputControl
    {
        public (float, float) CurrentInput();
    }
}