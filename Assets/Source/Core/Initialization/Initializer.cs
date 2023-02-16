using Agava.YandexGames;
using ElasticRush.Utilities;
using Lean.Localization;
using System.Collections.Generic;
using UnityEngine;

namespace ElasticRush
{
    public class Initializer : MonoBehaviour
    {
        [SerializeField] private List<LeanLanguage> _languages;
        [SerializeField] private string _startScene;

        private void Awake()
        {
            YandexGamesSdk.CallbackLogging = true;
        }

        private void Start()
        {
            SceneLoader.Instance.LoadScene(_startScene);
        }

        //        private IEnumerator Start()
        //        {
        //#if !UNITY_WEBGL || UNITY_EDITOR
        //            yield break;
        //#endif

        //            yield return YandexGamesSdk.Initialize();

        //            if (YandexGamesSdk.IsInitialized == false)
        //                throw new ArgumentNullException(nameof(YandexGamesSdk), "Yandex SDK didn't initialized correctly");

        //            SetLanguage();

        //            SceneLoader.Instance.LoadScene(_startScene);
        //        }

        private void SetLanguage()
        {
            LeanLanguage leanLanguage = null;
            string languageCode = YandexGamesSdk.Environment.i18n.lang;
            leanLanguage = _languages.Find(lang => lang.TranslationCode == languageCode);
            Config.Languages.CurrentLanguage = leanLanguage == null ? Config.Languages.DefaultLanguage : leanLanguage.name;

            LeanLocalization.SetCurrentLanguageAll(Config.Languages.CurrentLanguage);
        }
    }
}