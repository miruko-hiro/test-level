using System;
using System.Collections;
using Game.Characters.Enemies.Scripts.Gazing;
using Game.Characters.Enemies.Scripts.Rotation;
using Game.Scripts.UtilityAI;
using Game.Scripts.UtilityAI.Actions;
using Game.Scripts.UtilityAI.Scorers;
using Game.Weapons.Scripts.Balls;
using UnityEngine;

namespace Game.Characters.Enemies.Scripts.Shooting
{
    [RequireComponent(typeof(EnemyGazingSystem), typeof(EnemyRotationSystem))]
    public class EnemyShootingSystem : BaseAction
    {
        [SerializeField] private BallManager _ballManager;
        [SerializeField] private Transform _targetTransform;
        [SerializeField][Min(0f)] private float _timeBetweenShots = 2f;

        private EnemyGazingSystem _enemyGazingSystem;
        private EnemyRotationSystem _enemyRotationSystem;
        private IAnimation _animation;
        private ScoreKeeper _scoreKeeper;
        private Transform _transform;
        private float _nextFire;

        private void Awake()
        {
            _animation = GetComponent<EnemyShootingAnimation>();
            _transform = GetComponent<Transform>();
            _enemyGazingSystem = GetComponent<EnemyGazingSystem>();
            _enemyRotationSystem = GetComponent<EnemyRotationSystem>();
            _scoreKeeper = new ScoreKeeper(GetComponents<BaseScorer>());
        }

        public override float GetScores()
        {
            return _scoreKeeper.GetScores();
        }

        public override void Execute()
        {
            _enemyRotationSystem.LockOntoTarget(_targetTransform);
            if (_enemyGazingSystem.CheckIfTargetIsVisible(_targetTransform.position) && CheckShooting())
            {
                StartCoroutine(ShootCoroutine());
            }
        }

        private IEnumerator ShootCoroutine()
        {
            _animation.Run();
            yield return new WaitForSeconds(_animation.AnimationTime / 2f);
            _ballManager.ThrowBall(_transform.position, _targetTransform.position);
        }

        public override void Cancel()
        {
            _enemyRotationSystem.TakeOffTarget();
            _animation.Stop();
        }

        private bool CheckShooting()
        {
            var isShooting = Time.time > _nextFire;
            if(isShooting) _nextFire = Time.time + _timeBetweenShots;
            return isShooting;
        }

    }
}