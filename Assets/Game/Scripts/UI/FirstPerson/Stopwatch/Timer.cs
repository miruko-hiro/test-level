using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.FirstPerson.Stopwatch
{
    public class Timer : TimerBase
    {
        public override event Action<float> EventBestTimeSave;
        
        [SerializeField] private Text _bestTime;
        [SerializeField] private Text _time;
        
        private float _currentTime;
        private bool _stopwatchActive;

        public override void Initialize(float bestTime)
        {
            TimeSpan time = TimeSpan.FromSeconds(bestTime);
            _bestTime.text = $"{time.Minutes}:{time.Seconds}";
        }

        public override void TurnOn()
        {
            _currentTime = 0f;
            _time.text = "0:0";
            _stopwatchActive = true;
        }

        public override void TurnOff()
        {
            _stopwatchActive = false;
        }

        public override void CompareTime(float bestTime)
        {
            if(bestTime <= _currentTime && bestTime != 0f) return;
            
            TimeSpan time = TimeSpan.FromSeconds(_currentTime);
            _bestTime.text = $"{time.Minutes}:{time.Seconds}";    
            EventBestTimeSave?.Invoke(_currentTime);
        }

        private void Update()
        {
            Stopwatch();
        }

        private void Stopwatch()
        {
            if (_stopwatchActive)
            {
                _currentTime += Time.deltaTime;
                TimeSpan time = TimeSpan.FromSeconds(_currentTime);
                _time.text = $"{time.Minutes}:{time.Seconds}";
            }
        }
    }
}