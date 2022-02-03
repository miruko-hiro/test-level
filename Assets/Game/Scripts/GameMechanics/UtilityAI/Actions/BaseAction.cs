using UnityEngine;

namespace Game.Scripts.GameMechanics.UtilityAI.Actions
{
    public abstract class BaseAction : MonoBehaviour
    {
        public abstract void Initialize();
        public abstract float GetScores();
        public abstract void Execute();
        public abstract void Cancel();
    }
}