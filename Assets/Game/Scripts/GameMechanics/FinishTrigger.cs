using System;
using Game.Scripts.GameMechanics.Player;
using UnityEngine;

namespace Game.Scripts.GameMechanics
{
    public class FinishTrigger : MonoBehaviour
    {
        public event Action EventReachedFinish; 
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.TryGetComponent<ITarget>(out var target))
            {
                EventReachedFinish?.Invoke();
            }
        }
    }
}
