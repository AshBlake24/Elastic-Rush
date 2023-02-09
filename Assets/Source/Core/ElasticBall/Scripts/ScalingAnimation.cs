using DG.Tweening;
using ElasticRush.Core;
using UnityEngine;

namespace ElasticRush
{
    public class ScalingAnimation : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private float _targetScale;
        [SerializeField] private float _duration;

        private void OnEnable()
        {
            _player.EnemyAbsorbed += OnEnemyAbsorbed;
        }

        private void OnDisable()
        {
            _player.EnemyAbsorbed -= OnEnemyAbsorbed;
        }

        private void OnEnemyAbsorbed()
        {
            transform.DOScale(_targetScale, _duration / 2)
                     .From(Vector3.one)
                     .SetLoops(2, LoopType.Yoyo)
                     .SetEase(Ease.InOutQuad);
        }
    }
}
