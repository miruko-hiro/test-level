using System;
using UnityEngine;

namespace Game.Player.Scripts.Gazing
{
    public class PlayerGazingSystem : MonoBehaviour
    {
        public event Action<RaycastHit> EventHitIntoSomething; 
        public event Action EventHitIntoNothing; 
        
        [SerializeField] private Camera _mainCamera;

        private Transform _transformMainCamera;
        private int _layerIndexesToFind;

        private void Awake()
        {
            _transformMainCamera = _mainCamera.GetComponent<Transform>();
            _layerIndexesToFind = LayerMask.GetMask("Enemy") | LayerMask.GetMask("Impact");
        }

        private void Update()
        {
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
