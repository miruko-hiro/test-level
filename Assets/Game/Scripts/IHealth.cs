using System;

namespace Game.Scripts
{
    public interface IHealth
    {
        public event Action EventDeath;
    }
}