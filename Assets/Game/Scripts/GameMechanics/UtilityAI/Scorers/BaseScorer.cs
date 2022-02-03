using UnityEngine;

namespace Game.Scripts.GameMechanics.UtilityAI.Scorers
{
    public abstract class BaseScorer: MonoBehaviour
    {
        public abstract float GetScore();
    }
}