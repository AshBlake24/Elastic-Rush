using UnityEngine;
using UnityEngine.UI.Extensions;
using Agava.YandexGames;
using ElasticRush.UI;

namespace ElasticRush
{
    public class LeaderboardButton : Button
    {
        [SerializeField] private LeaderboardView _leaderboardView;

        protected override void OnButtonClick()
        {
            if (YandexGamesSdk.IsInitialized == false)
                return;

            if (PlayerAccount.IsAuthorized)
            {
                _leaderboardView.gameObject.SetActive(true);
            }
        }
    }
}
