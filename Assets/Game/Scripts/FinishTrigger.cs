using System;
using Game.Player.Scripts;
using UnityEngine;

namespace Game.Scripts
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
