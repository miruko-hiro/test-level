using System;

namespace Game.Scripts.GameMechanics.Characters
{
    public interface IHealth
    {
        public event Action EventDeath;
    }
}