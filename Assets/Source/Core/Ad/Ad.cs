using UnityEngine;
using Agava.YandexGames;
using ElasticRush.Core;

namespace ElasticRush
{
    public class Ad : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private void OnEnable()
        {
            _player.LevelCompleted += OnLevelCompleted;
            _player.Died += OnPlayerDied;
        }

        private void OnDisable()
        {
            _player.LevelCompleted -= OnLevelCompleted;
            _player.Died -= OnPlayerDied;
        }

        private void OnPlayerDied() => ShowAd();

        private void OnLevelCompleted() => ShowAd();

        private void ShowAd()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            if (YandexGamesSdk.IsInitialized)
                InterstitialAd.Show();
#endif
        }
    }
}