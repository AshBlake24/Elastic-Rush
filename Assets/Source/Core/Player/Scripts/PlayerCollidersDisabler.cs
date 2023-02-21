using ElasticRush.Core;
using UnityEngine;

namespace ElasticRush
{
    public class PlayerCollidersDisabler : MonoBehaviour
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

        private void OnLevelCompleted() => DisableColliders();

        private void OnDied() => DisableColliders();

        private void DisableColliders()
        {
            Collider[] colliders = GetComponentsInChildren<Collider>();

            foreach (Collider collider in colliders)
                collider.enabled = false;
        }
    }
}