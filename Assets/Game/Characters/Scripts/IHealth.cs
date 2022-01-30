using System;

namespace Game.Characters.Scripts
{
    public interface IHealth
    {
        public event Action EventDeath;
    }
}