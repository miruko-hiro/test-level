using System;
using UnityEngine;

namespace Game.Characters.Player.Scripts.Aiming
{
    public class PlayerAimingSystem : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField][Range(1, 179)] private int _normalFieldOfView = 60;
        [SerializeField][Range(1, 179)] private int _zoomFieldOfView = 40;
        [SerializeField] [Min(0f)] private float _smooth = 5f;
        private bool _isAim;

        private IAimingInputControl _aimingInputControl;

        private void Awake()
        {
            _aimingInputControl = new MouseAimingInputControl();
        }

        private void Update()
        {
            Aim();
        }

        private void Aim()
        {
            _mainCamera.fieldOfView = 
                Mathf.Lerp(_mainCamera.fieldOfView, 
                    _aimingInputControl.CurrentInput() ? _zoomFieldOfView : _normalFieldOfView, 
                    Time.deltaTime * _smooth);
        }
    }
}
