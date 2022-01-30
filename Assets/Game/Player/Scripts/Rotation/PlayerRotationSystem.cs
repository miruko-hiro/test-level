using UnityEngine;

namespace Game.Player.Scripts.Rotation
{
    public class PlayerRotationSystem : MonoBehaviour
    {
        [SerializeField] private float _sensitivity = 5f;
        [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
        [Range(0f, 90f)][SerializeField] private float _yRotationLimit = 88f;
        
        private Transform _transform;
        private Vector2 _rotation = Vector2.zero;
        private IRotationInputControl _rotationInputControl;
        
        private void Awake()
        {
            _rotationInputControl = new MouseRotationInputControl();
            _transform = GetComponent<Transform>();
        }

        private void Update()
        {
            Rotate();
        }

        private void Rotate()
        {
            var (x, y) = _rotationInputControl.CurrentInput();
            var vector = new Vector3(x, y, 0f);
            
            _rotation.x += vector.x * _sensitivity;
            _rotation.y += vector.y * _sensitivity;
            _rotation.y = Mathf.Clamp(_rotation.y, -_yRotationLimit, _yRotationLimit);
            
            var xQuat = Quaternion.AngleAxis(_rotation.x, Vector3.up);
            var yQuat = Quaternion.AngleAxis(_rotation.y, Vector3.left);
            _transform.localRotation = xQuat * yQuat;
        }
    }
}