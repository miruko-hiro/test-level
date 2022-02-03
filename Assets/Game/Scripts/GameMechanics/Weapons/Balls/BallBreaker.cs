using System.Collections;
using UnityEngine;

namespace Game.Scripts.GameMechanics.Weapons.Balls
{
    public class BallBreaker
    {
        private readonly BallDeathParticle _ballDeathParticle;
        private readonly int _layerIndexes;

        public BallBreaker(BallDeathParticle ballDeathParticle, int layerIndexes)
        {
            _ballDeathParticle = ballDeathParticle;
            _layerIndexes = layerIndexes;
        }
        
        public IEnumerator WaitingForDeathCoroutine(IBall ball, float lifetime)
        {
            if (!ball.IsEnable) yield break;
            yield return new WaitForSeconds(lifetime);
            if (!ball.IsEnable) yield break;
            _ballDeathParticle.Play(ball.Position);
            ball.Explosion(_layerIndexes);
        }

        public void Stop()
        {
            _ballDeathParticle.Stop();
        }
    }
}