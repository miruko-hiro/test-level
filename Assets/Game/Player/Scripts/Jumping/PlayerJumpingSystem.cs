using UnityEngine;

namespace Game.Player.Scripts.Jumping
{
    public class PlayerJumpingSystem : MonoBehaviour
    {
        [SerializeField] private float _jumpSpeed = 8f;
        [SerializeField] private float _gravityValue = 20f;
        
        private CharacterController _characterController;
        private IJumpingInputControl _jumpingInputControl;
        private Vector3 _playerVelocity;
        private float _gravityForce;
        
        private void Awake()
        {
            _jumpingInputControl = new KeyboardJumpingInputControl();
            _characterController = GetComponent<CharacterController>();
        }
        
        private void Update()
        {
            Jump();
        }

        private void Jump()
        {
            if (!_characterController.isGrounded)
                _gravityForce -= _gravityValue * Time.deltaTime;
            else
                _gravityForce = -1f;
            
            if (_jumpingInputControl.CurrentInput() && _characterController.isGrounded)
            {
                _playerVelocity.y = _jumpSpeed;
            }

            _playerVelocity.y = _gravityForce;
            _characterController.Move(_playerVelocity * Time.deltaTime);
        }
    }
}