namespace Game.Scripts.GameMechanics.Characters.Enemies
{
    public interface IAnimation
    {
        public float AnimationTime { get; }
        public void Run();
        public void Stop();
    }
}