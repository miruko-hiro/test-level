using UnityEngine;
using UnityEngine.AI;

namespace Game.Scripts.GameMechanics.Characters.Enemies.Movement
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMovementSystem : MonoBehaviour, IMovementStopper
    {
        [SerializeField] private Transform[] _targetPoints;
        [SerializeField] private bool _isMove = true;
        [SerializeField] private bool _isLoopPatrol = true;

        private IAnimation _movementAnimation;
        private NavMeshAgent _agent;
        private float _remainingDistance = 0.5f;
        private int _destPoint;
        private bool _isDeath;

        private void Awake()
        {
            if (_isMove)
            {
                _movementAnimation = new EnemyMovementAnimation(GetComponent<Animator>());
                _agent = GetComponent<NavMeshAgent>();

                if (_isLoopPatrol)
                {
                    _agent.autoBraking = false;
                }
            }
        }

        private void OnEnable()
        {
            if (_isMove)
            {
                _agent.isStopped = false;
                _isDeath = false;
                _movementAnimation.Run();
                if (_isLoopPatrol)
                    GotoNextPoint();
                else
                    GotoPoint(); 
            }
        }

        private void GotoNextPoint() {
            if (_targetPoints.Length == 0)
                return;

            _agent.destination = _targetPoints[_destPoint].position;
            _destPoint = (_destPoint + 1) % _targetPoints.Length;
        }

        private void GotoPoint() {
            if (_targetPoints.Length == 0)
                return;

            _agent.destination = _targetPoints[_destPoint].position;
        }

        public void Stop()
        {
            if (_isMove)
            {
                _agent.isStopped = true;
                _movementAnimation.Stop();
                _isDeath = true;
            }
        }
        
        private void Update () {
            if(!_isDeath && _isMove && _isLoopPatrol) 
                if (!_agent.pathPending && _agent.remainingDistance < _remainingDistance)
                    GotoNextPoint();
        }
    }
}