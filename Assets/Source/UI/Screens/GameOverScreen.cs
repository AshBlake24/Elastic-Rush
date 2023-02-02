using ElasticRush.Core;
using TMPro;
using UnityEngine;

namespace ElasticRush.UI
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private GameObject _gameOverScreen;

        private void Awake()
        {
            _gameOverScreen.SetActive(false);
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
            _gameOverScreen.SetActive(true);
        }
    }
}