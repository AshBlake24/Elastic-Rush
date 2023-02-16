using UnityEngine;
using UnityEngine.UI.Extensions;
using Agava.YandexGames;
using ElasticRush.Audio;
using ElasticRush.Utilities;

namespace ElasticRush.Core
{
    public class AdButton : Button
    {
        [SerializeField] private AudioGroupController _master;
        [SerializeField] private Player _player;

        protected override void OnButtonClick()
        {
            if (YandexGamesSdk.IsInitialized)
            {
                VideoAd.Show(Mute, Reward, Unmute);
            }
        }

        private void Mute() => _master.Mute();

        private void Unmute() => _master.Unmute();

        private void Reward() => SaveSystem.PlayerScore.Save(_player);
    }
}
