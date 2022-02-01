using System;
using UnityEngine;

namespace Game.Scripts.UtilityAI.Actions
{
    public abstract class BaseAction : MonoBehaviour
    {
        public abstract float GetScores();
        public abstract void Execute();
        public abstract void Cancel();
    }
}