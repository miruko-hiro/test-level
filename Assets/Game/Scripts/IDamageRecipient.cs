using System;

namespace Game.Scripts
{
    public interface IDamageRecipient
    {
        public event Action<int> EventHit;
        public void Hit(int damage);
    }
}