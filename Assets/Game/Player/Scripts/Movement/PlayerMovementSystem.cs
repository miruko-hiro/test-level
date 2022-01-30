using UnityEngine;

namespace Game.Player.Scripts.Movement
{
    public class PlayerMovementSystem : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        
        private CharacterController _characterController;
        private IMovementInputControl _movementInputControl;
        private Transform _transform;
        private Vector3 _playerVelocity;
        
        private void Awake()
        {
            _movementInputControl = new KeyboardMovementInputControl();
            _characterController = GetComponent<CharacterController>();
            _transform = GetComponent<Transform>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (_characterController.isGrounded)
            {
                var (x, z) = _movementInputControl.CurrentInput();
                _playerVelocity = new Vector3(x, 0f, z);
                _playerVelocity = _transform.TransformDirection(_playerVelocity);
                _playerVelocity *= _speed;
            }
            
            _characterController.Move(_playerVelocity * Time.deltaTime);
        }
    }
}