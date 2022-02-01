using Game.Scripts;
using UnityEngine;

namespace Game.Player.Scripts.Aiming
{
    public class PlayerAimingSystem : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField][Range(1, 179)] private int _normalFieldOfView = 60;
        [SerializeField][Range(1, 179)] private int _zoomFieldOfView = 40;
        [SerializeField] [Min(0f)] private float _smooth = 5f;

        private IAimingInputControl _aimingInputControl;
        public StateGame StateGame { get; set; } = StateGame.Pause;

        private void Awake()
        {
            _aimingInputControl = new MouseAimingInputControl();
        }

        private void Update()
        {
            if(StateGame == StateGame.Pause) return;
            
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
