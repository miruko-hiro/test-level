using System;
using Game.Scripts.GameMechanics.Core;
using UnityEngine;

namespace Game.Scripts.GameMechanics.Player.Gazing
{
    public class PlayerGazingSystem : MonoBehaviour
    {
        public event Action<RaycastHit> EventHitIntoSomething; 
        public event Action EventHitIntoNothing; 
        
        [SerializeField] private Camera _mainCamera;

        private Transform _transformMainCamera;
        private int _layerIndexesToFind;
        public StateGame StateGame { get; set; } = StateGame.Pause;

        private void Awake()
        {
            _transformMainCamera = _mainCamera.GetComponent<Transform>();
            _layerIndexesToFind = LayerMask.GetMask("Enemy") | LayerMask.GetMask("Impact");
        }

        private void Update()
        {
            if(StateGame == StateGame.Pause) return;
            
            See();
        }

        private void See()
        {
            var rayOrigin = _mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            if (Physics.Raycast(rayOrigin, _transformMainCamera.forward, out var hit, Mathf.Infinity, _layerIndexesToFind))
            {
                EventHitIntoSomething?.Invoke(hit);
            }
            else
            {
                EventHitIntoNothing?.Invoke();
            }
        }
    }
}
