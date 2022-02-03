using Game.Scripts.GameMechanics.Core;
using Game.Scripts.GameMechanics.Player.Jumping;
using Game.Scripts.GameMechanics.Player.Sprinting;
using UnityEngine;

namespace Game.Scripts.GameMechanics.Player.Movement
{
    public class PlayerMovementSystem : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private Transform _orientationTransform;
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _groundDrag = 6f;
        [SerializeField] private float _movementMultiplier = 5f;
        
        [Header("Jumping")]
        [SerializeField] private float _jumpForce = 10f;
        [SerializeField] private float _airDrag = 2f;
        //[SerializeField] private float _airMultiplier = 0.4f;
        [SerializeField] private float _groundDistance = 0.4f;
        [SerializeField] private Transform _groundCheck;

        [Header("Sprinting")] 
        [SerializeField] private float _walkSpeed = 4f;
        [SerializeField] private float _sprintSpeed = 6f;
        [SerializeField] private float _acceleration = 10f;
        
        private Rigidbody _rigidbody;
        private IMovementInputControl _movementInputControl;
        private IJumpingInputControl _jumpingInputControl;
        private ISprintingInputControl _sprintingInputControl;
        public StateGame StateGame { get; set; } = StateGame.Pause;
        private Transform _transform;
        private Vector3 _moveDirection;
        private bool _isGrounded;
        private int _groundLayerIndex;
        
        private void Awake()
        {
            _movementInputControl = new KeyboardMovementInputControl();
            _jumpingInputControl = new KeyboardJumpingInputControl();
            _sprintingInputControl = new KeyboardSprintingInputControl();
            _transform = GetComponent<Transform>();
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.freezeRotation = true;
            _groundLayerIndex = LayerMask.GetMask("Impact");
        }

        private void Update()
        {
            if(StateGame == StateGame.Pause) return;
            
            CheckGrounded();
            InputMove();
            ControlDrag();
            ControlSpeed();
            Jump();
        }

        private void ControlSpeed()
        {
            if (_sprintingInputControl.CurrentInput() && _isGrounded)
            {
                _speed = Mathf.Lerp(_speed, _sprintSpeed, _acceleration * Time.deltaTime);
            }
            else
            {
                _speed = Mathf.Lerp(_speed, _walkSpeed, _acceleration * Time.deltaTime);
            }
        }

        private void ControlDrag()
        {
            _rigidbody.drag = _isGrounded ? _groundDrag : _airDrag;
        }

        private void InputMove()
        {
            var (x, z) = _movementInputControl.CurrentInput();
            _moveDirection = _orientationTransform.forward * z + _orientationTransform.right * x;
            
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void CheckGrounded()
        {
            _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundLayerIndex);
        }

        private void Jump()
        {
            if (_jumpingInputControl.CurrentInput() && _isGrounded)
            {
                _rigidbody.AddForce(_transform.up * _jumpForce, ForceMode.Impulse);
            }
        }

        private void Move()
        {
            if(_isGrounded)
                _rigidbody.AddForce(_moveDirection.normalized * (_speed * _movementMultiplier), ForceMode.Acceleration);
            // else
            //     _rigidbody.AddForce(_moveDirection.normalized * (_speed * _airMultiplier), ForceMode.Acceleration);
        }
    }
}