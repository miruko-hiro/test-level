using Game.Scripts.GameMechanics.Player.Rotation;
using UnityEngine;

namespace Game.Scripts.GameMechanics.Weapons
{
    public class WeaponSway: MonoBehaviour
    {
        [Header("Sway Settings")] 
        [SerializeField] private float smooth = 8f;
        [SerializeField] private float swayMultiplier = 2f;

        private IRotationInputControl _rotationInputControl;
        private Transform _transform;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _rotationInputControl = new MouseRotationInputControl();
            _transform = GetComponent<Transform>();
        }

        private void Update()
        {
            Sway();
        }

        private void Sway()
        {
            var (x, y) = _rotationInputControl.CurrentInput();

            var rotationX = Quaternion.AngleAxis(-(y * swayMultiplier), Vector3.right);
            var rotationY = Quaternion.AngleAxis(x * swayMultiplier, Vector3.up);
            var targetRotation = rotationX * rotationY;
            
            _transform.localRotation = Quaternion.Slerp(_transform.localRotation, targetRotation, smooth * Time.deltaTime);
        }
    }
}