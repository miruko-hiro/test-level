using Game.Scripts.GameMechanics.Core;
using UnityEngine;

namespace Game.Scripts.GameMechanics.Player.Rotation
{
    public class PlayerRotationSystem : MonoBehaviour
    {
        [SerializeField] private float _sensitivity = 5f;
        [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
        [Range(0f, 90f)][SerializeField] private float _yRotationLimit = 88f;
        [SerializeField] private Transform _mainCameraTransform;
        [SerializeField] private Transform _orientationTransform;
        
        private float _xRotation;
        private float _yRotation;
        private IRotationInputControl _rotationInputControl;
        public StateGame StateGame { get; set; } = StateGame.Pause;
        
        private void Awake()
        {
            _rotationInputControl = new MouseRotationInputControl();
        }

        private void Update()
        {
            if (StateGame == StateGame.Pause)
            {
                _xRotation = 0f;
                _yRotation = 0f;
                return;
            }
            
            Rotate();
        }

        private void Rotate()
        {
            var (x, y) = _rotationInputControl.CurrentInput();
            
            _yRotation += x * _sensitivity;
            _xRotation -= y * _sensitivity;
            _xRotation = Mathf.Clamp(_xRotation, -_yRotationLimit, _yRotationLimit);
            
            _mainCameraTransform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
            _orientationTransform.rotation = Quaternion.Euler(0f, _yRotation, 0f);
        }
    }
}