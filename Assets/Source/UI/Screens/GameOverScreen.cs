using ElasticRush.Core;
using UnityEngine;

namespace ElasticRush.UI
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private GameObject _screen;

        private void Awake()
        {
            _screen.SetActive(false);
        }

        private void OnEnable()
        {
            _player.Died += OnPlayerDied;
        }

        private void OnDisable()
        {
            _player.Died -= OnPlayerDied;
        }

        private void OnPlayerDied()
        {
            _screen.SetActive(true);
        }
    }
}