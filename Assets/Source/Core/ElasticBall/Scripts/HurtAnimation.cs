using DG.Tweening;
using UnityEngine;

namespace ElasticRush.Core
{
    public class HurtAnimation : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Material _playerMaterial;
        [SerializeField] private Color _targetColor;
        [SerializeField] private float _targetScale;
        [SerializeField] private float _duration;

        private Sequence _sequence;
        private Tween _scalingTween;
        private Tween _colorTween;

        private void Start()
        {
            _scalingTween = transform
                .DOScale(_targetScale, _duration / 2)
                .From(Vector3.one)
                .SetLoops(2, LoopType.Yoyo)
                .SetEase(Ease.InOutQuad);

            _colorTween = _playerMaterial
                .DOColor(_targetColor, _duration / 2)
                .From(Color.white)
                .SetLoops(2, LoopType.Yoyo)
                .SetEase(Ease.InOutQuad);

            _sequence = DOTween.Sequence();
            _sequence.Append(_scalingTween).Insert(0, _colorTween).SetAutoKill(false);
        }

        private void OnEnable()
        {
            _player.DamageReceived += OnDamageReceived;
        }

        private void OnDisable()
        {
            _player.DamageReceived -= OnDamageReceived;
        }

        private void OnDamageReceived()
        {
            _sequence.Restart();
        }
    }
}
