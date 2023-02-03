using ElasticRush.Core;
using TMPro;
using UnityEngine;

namespace ElasticRush.UI
{
    public class LevelCompletedScreen : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private GameObject _levelCompletedScreen;

        private void Awake()
        {
            _levelCompletedScreen.SetActive(false);
        }

        private void OnEnable()
        {
            _player.LevelCompleted += OnLevelCompleted;
        }

        private void OnDisable()
        {
            _player.LevelCompleted -= OnLevelCompleted;
        }

        private void OnLevelCompleted()
        {
            _levelCompletedScreen.SetActive(true);
        }
    }
}