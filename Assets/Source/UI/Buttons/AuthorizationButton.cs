using UnityEngine;
using UnityEngine.UI.Extensions;
using Agava.YandexGames;

namespace ElasticRush.UI
{
    public class AuthorizationButton : Button
    {
        [SerializeField] private GameObject _authorizationScreen;

        protected override void OnButtonClick()
        {
            if (YandexGamesSdk.IsInitialized)
            {
                PlayerAccount.Authorize();
                _authorizationScreen.SetActive(false);
            }
        }
    }
}
