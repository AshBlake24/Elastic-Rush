using UnityEngine;
using DG.Tweening;

namespace ElasticRush.Core
{
    public class ScalingAnimation : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private float _targetScale;
        [SerializeField] private float _duration;

        private void OnEnable()
        {
            _player.EnemyAbsorbed += OnEnemyAbsorbed;
            _player.DamageReceived += OnDamageReceived;
            _player.Died += OnDied;
        }

        private void OnDisable()
        {
            _player.EnemyAbsorbed -= OnEnemyAbsorbed;
            _player.DamageReceived -= OnDamageReceived;
            _player.Died -= OnDied;
        }

        private void PlayPoppingAnimation()
        {
            transform.DOScale(_targetScale, _duration / 2)
                     .From(Vector3.one)
                     .SetLoops(2, LoopType.Yoyo)
                     .SetEase(Ease.InOutQuad);
        }

        private void PlayDyingAnimation()
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Append(
                transform.DOScale(_targetScale, _duration / 2)
                .From(Vector3.one)
                .SetEase(Ease.InQuad));

            sequence.Append(
                transform.DOScale(Vector3.zero, _duration)
                .SetEase(Ease.OutQuad));

            sequence.Play();
        }

        private void OnDamageReceived() => PlayPoppingAnimation();

        private void OnEnemyAbsorbed() => PlayPoppingAnimation();

        private void OnDied() => PlayDyingAnimation();
    }
}
