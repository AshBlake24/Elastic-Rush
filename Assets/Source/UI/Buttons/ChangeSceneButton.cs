using Agava.YandexGames;
using UnityEngine.SceneManagement;
using UnityEngine.UI.Extensions;

namespace ElasticRush
{
    public class ChangeSceneButton : Button
    {
        private string _nextSceneName;

        public void Init(string nextSceneName) => _nextSceneName = nextSceneName;

        protected override void OnButtonClick()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneLoader.Instance.ChangeScene(_nextSceneName, currentSceneName);
            ShowAd();
        }

        private void ShowAd()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            if (YandexGamesSdk.IsInitialized)
                InterstitialAd.Show();
#endif
        }
    }
}