namespace Game.Characters.Player.Scripts.Rotation
{
    public interface IRotationInputControl
    {
        public (float, float) CurrentInput();
    }
}