using UnityEngine;

namespace Game.Scripts.GameMechanics.Weapons.Balls
{
    public interface IBall
    {
        public bool IsEnable { get; }
        public Vector3 Position { get; }
        public void ThrowWithForce(Vector3 startPosition, Vector3 force);
        public void Explosion(int layerIndexes);
    }
}