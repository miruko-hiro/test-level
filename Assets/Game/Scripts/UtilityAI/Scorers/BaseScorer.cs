using UnityEngine;

namespace Game.Scripts.UtilityAI.Scorers
{
    public abstract class BaseScorer: MonoBehaviour
    {
        public abstract float GetScore();
    }
}