using System;
using UnityEngine;

namespace Game.Player.Scripts
{
    public class MoveCamera : MonoBehaviour
    {
        [SerializeField] private Transform _cameraTransform;

        private Transform _transform;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        private void LateUpdate()
        {
            _transform.position = _cameraTransform.position;
        }
    }
}
