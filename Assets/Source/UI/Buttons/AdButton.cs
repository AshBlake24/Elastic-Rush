using UnityEngine;
using UnityEngine.UI.Extensions;
using Agava.YandexGames;
using ElasticRush.Audio;
using ElasticRush.Utilities;
using System;

namespace ElasticRush.Core
{
    public class AdButton : Button
    {
        [SerializeField] private AudioGroupController _master;

        private Player _player;
        private bool _isUsed;

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

        private void Mute() => _master.Mute();

        private void Unmute() => _master.Unmute();

        private void Reward() => _player.AddExtraScore();
    }
}
