using UnityEngine;

namespace Game.Characters.Player.Scripts.Movement
{
    public class PlayerMovementSystem : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        
        private Vector3 _playerVelocity;
        private Transform _transform;
        private CharacterController _characterController;
        private IMovementInputControl _movementInputControl;
        
        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _characterController = GetComponent<CharacterController>();
            _movementInputControl = new KeyboardMovementInputControl();
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