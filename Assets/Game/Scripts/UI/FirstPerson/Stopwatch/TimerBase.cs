using System;
using UnityEngine;

namespace Game.Scripts.UI.FirstPerson.Stopwatch
{
    public abstract class TimerBase : MonoBehaviour
    {
        public abstract event Action<float> EventBestTimeSave;
        public abstract void Initialize(float bestTime);
        public abstract void TurnOn();
        public abstract void TurnOff();
        public abstract void CompareTime(float bestTime);
    }
}