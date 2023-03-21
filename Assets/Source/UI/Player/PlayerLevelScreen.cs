using ElasticRush.Core;
using TMPro;
using UnityEngine;

namespace ElasticRush.UI
{
    public class PlayerLevelScreen : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private float _localSize;

        private void Awake()
        {
            _localSize = transform.localScale.x;
        }

        private void OnEnable()
        {
            _player.Died += OnDied;
            _player.LevelCompleted += OnLevelCompleted;
            _player.ElasticBall.SizeChanged += OnLevelChanged;
        }

        private void OnDisable()
        {
            _player.Died -= OnDied;
            _player.LevelCompleted -= OnLevelCompleted;
            _player.ElasticBall.SizeChanged -= OnLevelChanged;
        }

        private void OnLevelChanged(float ballSize)
        {
            transform.localScale = Vector3.one * (_localSize / ballSize);
        }

        private void Destroy() => Destroy(gameObject);

        private void OnLevelCompleted() => Destroy();

        private void OnDied() => Destroy();
    }
}