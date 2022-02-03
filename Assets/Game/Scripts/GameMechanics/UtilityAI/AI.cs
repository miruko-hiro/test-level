using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game.Scripts.GameMechanics.UtilityAI.Actions;
using UnityEngine;

namespace Game.Scripts.GameMechanics.UtilityAI
{
    public class AI: MonoBehaviour
    {
        [SerializeField] private float updateTime = 0.1f;
        
        private List<BaseAction> _actions;
        private bool _isEnable = true;
        private Coroutine _coroutine;
        
        public bool IsEnable
        {
            get => _isEnable;
            set => _isEnable = value;
        }

        private void Awake()
        {
            _actions = GetComponentsInChildren<BaseAction>().ToList();
            foreach (var baseAction in _actions)
            {
                baseAction.Initialize();
            }
        }
        
        private void OnEnable()
        {
            _coroutine = StartCoroutine(SelectActionAI());
        }
        
        private IEnumerator SelectActionAI()
        {
            BaseAction actionInProgress = _actions.OrderBy(p => p.GetScores()).Last();
                
            while (_isEnable)
            {
                yield return new WaitForSeconds(updateTime);
                
                var biggestAction = _actions.OrderBy(p => p.GetScores()).Last();
                if (!biggestAction.Equals(actionInProgress))
                {
                    if (biggestAction.GetScores() > 0)
                    {
                        actionInProgress.Cancel();
                        biggestAction.Execute();
                        actionInProgress = biggestAction;
                    }
                }
                else
                {
                    if(actionInProgress.GetScores() > 0)
                    {
                        actionInProgress.Execute();
                    }
                }
            }
            
            foreach (var action in _actions)
            {
                action.Cancel();
            }
        }

        private void OnDisable()
        {
            StopCoroutine(_coroutine);
        }
    }
}