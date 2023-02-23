using ElasticRush.Core;
using UnityEngine;

namespace ElasticRush.UI
{
    public class PlayerLevelScreen : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private void OnEnable()
        {
            _player.Died += OnDied;
            _player.LevelCompleted += OnLevelCompleted;
        }

        private void OnDisable()
        {
            _player.Died -= OnDied;
            _player.LevelCompleted -= OnLevelCompleted;
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }

        private void OnLevelCompleted() => Destroy();

        private void OnDied() => Destroy();
    }
}