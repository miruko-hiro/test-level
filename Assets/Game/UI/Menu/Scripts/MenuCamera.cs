using System;
using DG.Tweening;
using UnityEngine;

namespace Game.UI.Menu.Scripts
{
    public class MenuCamera : MonoBehaviour
    {
        [SerializeField] private Vector3[] _points;
        [SerializeField] private Vector3 _center;
        [SerializeField] private float _time;
        
        private Sequence _sequence;

        private void Awake()
        {
            _sequence = DOTween.Sequence()
                .Append(transform.DOPath(_points, _time, PathType.CatmullRom, PathMode.Full3D, 5)
                    .SetLookAt(_center, true)
                    .SetEase(Ease.Linear))
                .SetLoops(-1, LoopType.Restart)
                .SetAutoKill(false);
        }

        private void OnEnable()
        {
            Play();
        }

        public void Play()
        {
            _sequence.Play();
        }

        public void Stop()
        {
            _sequence.Pause();
        }

        private void OnDisable()
        {
            Stop();
        }

        private void OnDestroy()
        {
            _sequence.Kill();
        }
    }
}
