using System.Collections.Generic;
using System.Linq;
using Game.Scripts.GameMechanics.UtilityAI.Scorers;

namespace Game.Scripts.GameMechanics.UtilityAI
{
    public class ScoreKeeper
    {
        private readonly List<BaseScorer> _scorers;

        public ScoreKeeper(params BaseScorer[] scorers)
        {
            _scorers = scorers.ToList();
        }

        public float GetScores()
        {
            float score = 0f;
            
            foreach (var scorer in _scorers)
            {
                score += scorer.GetScore();
            }

            return score;
        }
    }
}