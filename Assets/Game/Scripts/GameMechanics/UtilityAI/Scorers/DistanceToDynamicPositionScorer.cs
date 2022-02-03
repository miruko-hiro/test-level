﻿using UnityEngine;

namespace Game.Scripts.GameMechanics.UtilityAI.Scorers
{
    public class DistanceToDynamicPositionScorer: BaseScorer
    {
        [SerializeField] private Transform transformOwn;
        [SerializeField] private Transform transformEnemy;
        [SerializeField] private float minDistance;
        [SerializeField] private float maxDistance;
        [SerializeField] private float closeScore;
        [SerializeField] private float farScore;

        public float CloseScore => closeScore;
        public float FarScore => farScore;
        public float MinDistance => minDistance;
        public float MaxDistance => maxDistance;
        public Vector3 DynamicPosition => transformEnemy.position;
        
        public bool IsAggressive { get; set; }

        public Transform TransformEnemy
        {
            get => transformEnemy;
            set => transformEnemy = value;
        }

        public override float GetScore()
        {
            if (IsAggressive)
                return closeScore < farScore ? farScore: closeScore;
            
            var distance =  Vector3.Distance(transformOwn.position, transformEnemy.position);

            if (distance <= minDistance) return closeScore;
            if (distance >= maxDistance) return farScore;

            var y = (distance - minDistance) * (Mathf.Abs(closeScore - farScore) / (maxDistance - minDistance));
            return closeScore < farScore ? closeScore + y : closeScore - y;
        }
    }
}