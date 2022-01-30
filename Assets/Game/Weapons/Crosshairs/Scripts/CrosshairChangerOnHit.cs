using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Weapons.Crosshairs.Scripts
{
    public class CrosshairChangerOnHit : MonoBehaviour, ICrosshairChanger
    {
        [SerializeField] private Image _hitCrosshair;
        
        private Sequence _sequence;
        private float _duration = 0.1f;

        private void Awake()
        {
            _sequence = DOTween.Sequence()
                .Insert(0f,
                    _hitCrosshair.rectTransform.DOSizeDelta(new Vector2(120f, 120f), _duration * 4)
                        .From(new Vector2(70f, 70f)))
                .Insert(0f, _hitCrosshair.DOFade(1f, _duration))
                .Insert(_duration * 2f, _hitCrosshair.DOFade(0f, _duration))
                .SetAutoKill(false);
            
            _sequence.Pause();
        }

        public void Change()
        {
            _sequence.Restart();
        }

        public void UndoChange()
        {
            _sequence.Pause();
            _hitCrosshair.rectTransform.sizeDelta = new Vector2(70f, 70f);
            var color = _hitCrosshair.color; color.r = 0f; _hitCrosshair.color = color;
        }

        private void OnDestroy()
        {
            _sequence.Kill();
        }
    }
}