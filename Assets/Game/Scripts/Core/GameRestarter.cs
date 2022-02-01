using System;
using Game.Characters.Enemies.Scripts;
using Game.Player.Scripts;
using Game.Scripts.Core.Configs;
using Game.Weapons.Scripts.Balls;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class GameRestarter : MonoBehaviour
    {
        [SerializeField] private PlayerTarget _playerTarget;
        [SerializeField] private Transform _cameraHolder;
        [Space(10)]
        [SerializeField] private EnemyTarget[] _enemyTargets;

        [SerializeField] private BallManager _ballManager;

        public void Restart()
        {
            var config = Resources.Load<TestLevelConfig>("TestLevelConfig");

            _playerTarget.transform.position = config.PlayerPosition;
            _cameraHolder.localRotation = Quaternion.Euler(config.PlayerRotation);

            var enemiesPositions = config.EnemiesPositions;
            for (int i = 0; i < enemiesPositions.Length; i++)
            {
                _enemyTargets[i].gameObject.SetActive(true);
                _enemyTargets[i].transform.position = enemiesPositions[i];
            }
            
            _ballManager.DisableAllBall();
        }
    }
}