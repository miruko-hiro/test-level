using UnityEngine;

namespace Game.Scripts.GameMechanics.Weapons.Balls
{
    public class BallManager : MonoBehaviour
    {
        [SerializeField] private int _numberOfBalls;
        [SerializeField] private float _lifetime;
        [SerializeField] private float _power = 2f;

        private BallSpawner _ballSpawner;
        private BallThrower _ballThrower;
        private BallBreaker _ballBreaker;

        private void Awake()
        {
            _ballSpawner = new BallSpawner(_numberOfBalls, transform);
            _ballThrower = new BallThrower(_power);
            
            var obj = Resources.Load<GameObject>("Death Effect Ball");
            var ballDeathParticle = Instantiate(obj).GetComponent<BallDeathParticle>();
            _ballBreaker = new BallBreaker(ballDeathParticle, LayerMask.GetMask("Player"));
        }

        public void ThrowBall(Vector3 startPosition, Vector3 endPosition)
        {
            var ball = _ballSpawner.GetBall();
            _ballThrower.ThrowBall(ball, startPosition, endPosition);
            StartCoroutine(_ballBreaker.WaitingForDeathCoroutine(ball, _lifetime));
        }

        public void DisableAllBall()
        {
            StopAllCoroutines();
            _ballBreaker.Stop();
            _ballSpawner.DisableAll();
        }
    }
}