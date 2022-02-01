using UnityEngine;

namespace Game.Weapons.Scripts.Balls
{
    public class BallThrower
    {
        private readonly float _power;

        public BallThrower(float power)
        {
            _power = power;
        }

        public void ThrowBall(IBall ball, Vector3 startPosition, Vector3 endPosition)
        {
            var direction = endPosition - startPosition;
            startPosition += direction.normalized;
            startPosition.y += 1f;
            ball.ThrowWithForce(startPosition, direction * _power);
        }
    }
}