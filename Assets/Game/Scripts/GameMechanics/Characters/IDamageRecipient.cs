using System;

namespace Game.Scripts.GameMechanics.Characters
{
    public interface IDamageRecipient
    {
        public event Action<int> EventHit;
        public void Hit(int damage);
    }
}