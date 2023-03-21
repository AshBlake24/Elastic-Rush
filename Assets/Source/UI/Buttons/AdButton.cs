using UnityEngine;
using UnityEngine.UI.Extensions;
using Agava.YandexGames;
using System;

namespace ElasticRush.Core
{
    public class AdButton : Button
    {
        private Player _player;
        private bool _isUsed;

        public static event Action AdOpened;
        public static event Action AdClosed;

        private void Start()
        {
            _isUsed = false;
            ButtonComponent.interactable = true;
        }

        public void Init(Player player)
        {
            _player = player;
        }

        protected override void OnButtonClick()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            if (YandexGamesSdk.IsInitialized && _isUsed == false)
            {
                VideoAd.Show(Mute, Reward, Unmute);
                _isUsed = true;
                ButtonComponent.interactable = false;
            }
#endif
        }

        private void Mute() => AdOpened?.Invoke();

        private void Unmute() => AdClosed?.Invoke();

        private void Reward() => _player.AddExtraScore();
    }
}
