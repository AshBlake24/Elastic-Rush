using UnityEngine;
using UnityEngine.UI.Extensions;
using Agava.YandexGames;
using ElasticRush.UI;

namespace ElasticRush
{
    public class LeaderboardButton : Button
    {
        [SerializeField] private LeaderboardView _leaderboardView;
        [SerializeField] private GameObject _authorizationScreen;

        protected override void OnButtonClick()
        {
            if (YandexGamesSdk.IsInitialized == false)
                return;

            if (PlayerAccount.IsAuthorized)
                _leaderboardView.gameObject.SetActive(true);
            else
                _authorizationScreen.SetActive(true);

            Debug.Log($"Player auth - {PlayerAccount.IsAuthorized}");
        }
    }
}
