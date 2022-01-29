using System;
using System.Collections;
using DG.Tweening;
using Game.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Weapons.Scripts
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField][Min(0f)] private float _timeBetweenShots = 2f;
        [SerializeField][Min(0)] private int _damage = 1;
        [SerializeField][Min(1f)] private float _weaponRange = 500f;
        [SerializeField] private Image _hitCrosshair;

        private IHitEffect _hitEffect;
        private IShootEffect _shootEffect;
        private IWeaponAnimation _weaponAnimation;
        private float _nextFire;
        private int _enemyLayerIndex;
        private int _impactLayerIndex;
        private Sequence _sequence;
        private float _duration = 0.1f;

        private void Awake()
        {
            _hitEffect = GetComponentInChildren<IHitEffect>();
            _shootEffect = GetComponentInChildren<IShootEffect>();
            _weaponAnimation = GetComponent<IWeaponAnimation>();
            _enemyLayerIndex = LayerMask.GetMask("Enemy");
            _impactLayerIndex = LayerMask.GetMask("Impact");

            _sequence = DOTween.Sequence()
                .Insert(0f, _hitCrosshair.rectTransform.DOSizeDelta(new Vector2(120f, 120f), _duration * 4).From(new Vector2(70f, 70f)))
                .Insert(0f, _hitCrosshair.DOFade(1f, _duration))
                .Insert(_duration *  2f, _hitCrosshair.DOFade(0f, _duration))
                .SetAutoKill(false)
                .Pause();
        }

        public bool CanShoot()
        {
            return Time.time > _nextFire;
        }

        public void Shoot(Vector3 rayOrigin, Vector3 cameraTransformForward)
        {
            _nextFire = Time.time + _timeBetweenShots;

            if (Physics.Raycast(rayOrigin, cameraTransformForward, out var hit, _weaponRange, _enemyLayerIndex | _impactLayerIndex))
            {
                var damageRecipient = hit.transform.GetComponent<IDamageRecipient>();
                if (damageRecipient != null)
                {
                    damageRecipient.Hit(_damage);
                    _sequence.Restart();
                }
                HitEffect(hit.point, Quaternion.LookRotation(hit.normal));
            }

            ShootEffect();
        }

        private void HitEffect(Vector3 position, Quaternion rotation)
        {
            _hitEffect?.Show(position, rotation);
        }

        private void ShootEffect()
        {
            _shootEffect?.Show();
            _weaponAnimation?.ShootAnimation();
        }

        private void OnDestroy()
        {
            _sequence.Kill();
        }
    }
}