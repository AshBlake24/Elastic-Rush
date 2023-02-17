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
        }

        private void OnDisable()
        {
            _player.LevelCompleted -= OnLevelCompleted;
        }

        private void OnLevelCompleted()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            if (YandexGamesSdk.IsInitialized)
                InterstitialAd.Show();
#endif
        }
    }
}