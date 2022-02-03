using System;
using Game.Scripts.UI.FirstPerson.Stopwatch;
using UnityEngine;

namespace Game.Scripts.GameMechanics.Core
{
    public class TimerManager : MonoBehaviour
    {
        [SerializeField] private TimerBase _timer;
        private DataStorage _dataStorage;

        private void Awake()
        {
            _dataStorage = new DataStorage();
            _timer.EventBestTimeSave += BestTimeSave;
            _timer.Initialize(_dataStorage.GetBestTime());
        }

        private void BestTimeSave(float bestTime)
        {
            _dataStorage.SetBestTime(bestTime);
        }

        public void StartTimer()
        {
            _timer.gameObject.SetActive(true);
            _timer.TurnOn();
        }

        public void StopTimerWithoutRecording()
        {
            _timer.TurnOff();
        }

        public void StopTimerWithRecording()
        {
            _timer.TurnOff();
            _timer.CompareTime(_dataStorage.GetBestTime());
        }

        private void OnDestroy()
        {
            _timer.EventBestTimeSave -= BestTimeSave;
        }
    }
}