using Game.Helpers.Scripts;
using UnityEngine;

namespace Game.Weapons.Scripts.Balls
{
    public class BallSpawner
    {
        private PoolMono<Ball> _ballPool;

        public BallSpawner(int numberOfBalls, Transform container)
        {
            var ball = Resources.Load<Ball>("Ball");
            _ballPool = new PoolMono<Ball>(ball, numberOfBalls, container);
        }

        public IBall GetBall()
        {
            return _ballPool.GetFreeElement();
        }

        public void DisableAll()
        {
            _ballPool.DisableAll();
        }
    }
}