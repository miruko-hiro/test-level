namespace Game.Characters.Enemies.Scripts
{
    public interface IAnimation
    {
        public float AnimationTime { get; }
        public void Initialize();
        public void Run();
        public void Stop();
    }
}