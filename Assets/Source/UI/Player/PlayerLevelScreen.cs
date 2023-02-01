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
        }

        private void OnDisable()
        {
            _player.Died -= OnDied;
        }

        private void OnDied()
        {
            Destroy(gameObject);
        }
    }
}