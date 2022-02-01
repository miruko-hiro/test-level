namespace Game.Characters.Enemies.Scripts
{
    public interface IAnimation
    {
        public float AnimationTime { get; }
        public void Run();

        public void Stop();
    }
}