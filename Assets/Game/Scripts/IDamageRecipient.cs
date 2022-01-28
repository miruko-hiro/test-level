using System;

namespace Game.Scripts
{
    public interface IDamageRecipient
    {
        public event Action EventDeath;
        public void Hit(int damage);
    }
}