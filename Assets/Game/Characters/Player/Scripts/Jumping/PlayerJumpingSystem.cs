using UnityEngine;

namespace Game.Characters.Player.Scripts.Jumping
{
    public class PlayerJumpingSystem : MonoBehaviour
    {
        [SerializeField] private float _jumpSpeed = 8f;
        [SerializeField] private float _gravityValue = 20f;
        
        private Vector3 _playerVelocity;
        private CharacterController _characterController;
        private IJumpingInputControl _jumpingInputControl;
        private float _gravityForce;
        
        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _jumpingInputControl = new KeyboardJumpingInputControl();
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

            Debug.Log(_characterController.isGrounded);
            
            if (_jumpingInputControl.CurrentInput() && _characterController.isGrounded)
            {
                _playerVelocity.y = _jumpSpeed;
            }

            _playerVelocity.y = _gravityForce;
            _characterController.Move(_playerVelocity * Time.deltaTime);
        }
    }
}