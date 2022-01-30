using UnityEngine;
using UnityEngine.AI;

namespace Game.Characters.Enemies.Scripts.Movement
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMovementSystem : MonoBehaviour, IMovementStopper
    {
        [SerializeField] private Transform[] _targetPoints;
        [SerializeField] private bool _isMove = true;
        [SerializeField] private bool _isLoopPatrol = true;

        private IMovementAnimation _movementAnimation;
        private NavMeshAgent _agent;
        private float _remainingDistance = 0.5f;
        private int _destPoint;

        private void Awake()
        {
            if (_isMove)
            {
                _movementAnimation = GetComponent<EnemyMovementAnimation>();
                _agent = GetComponent<NavMeshAgent>();

                if (_isLoopPatrol)
                {
                    _agent.autoBraking = false;
                }
            }
        }

        private void Start()
        {
            if (_isMove)
            {
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
                _isMove = _isLoopPatrol = false;
            }
        }
        
        private void Update () {
            if(_isMove && _isLoopPatrol) 
                if (!_agent.pathPending && _agent.remainingDistance < _remainingDistance)
                    GotoNextPoint();
        }
    }
}