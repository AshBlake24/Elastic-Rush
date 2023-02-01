using ElasticRush.Core;
using TMPro;
using UnityEngine;

namespace ElasticRush.UI
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private GameObject _screen;
        [SerializeField] private TMP_Text _score;

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
            _score.text = $"Score: {_player.Score}";

        }
    }
}