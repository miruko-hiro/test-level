using UnityEngine;

namespace Game.Scripts.GameMechanics.Core.Configs
{
    [CreateAssetMenu(fileName = "TestLevelConfig", menuName = "Configs/Test Level Config", order = 0)]
    public class TestLevelConfig : ScriptableObject
    {
        [Header("Starting Positions")]
        [SerializeField] private Vector3 _playerPosition;
        [SerializeField] private Vector3 _playerRotation;
        [Space(10)]
        [SerializeField] private Vector3[] _enemiesPositions;

        public Vector3 PlayerPosition
        {
            get => _playerPosition;
            set => _playerPosition = value;
        }

        public Vector3 PlayerRotation
        {
            get => _playerRotation;
            set => _playerRotation = value;
        }

        public Vector3[] EnemiesPositions
        {
            get => _enemiesPositions;
            set => _enemiesPositions = value;
        }
    }
}