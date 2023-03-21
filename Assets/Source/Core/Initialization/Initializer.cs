using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using ElasticRush.Utilities;
using Lean.Localization;

namespace ElasticRush.Core
{
    public class Initializer : MonoBehaviour
    {
        [SerializeField] private Stage _stageToLoad;
        [SerializeField] private List<LeanLanguage> _languages;

        private string _stage;

        private void Awake()
        {
            YandexGamesSdk.CallbackLogging = true;
        }

        private IEnumerator Start()
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            SetLanguage();
            _stage = GetStageToLoad();
            SceneLoader.Instance.LoadScene(_stage);
            yield break;
#endif

            yield return YandexGamesSdk.Initialize();

            if (YandexGamesSdk.IsInitialized == false)
                throw new ArgumentNullException(nameof(YandexGamesSdk), "Yandex SDK didn't initialized correctly");

            SetLanguage();
            RequestData();

            _stage = SaveSystem.Stage.Load();
            SceneLoader.Instance.LoadScene(_stage);
            StickyAd.Show();
        }

        private string GetStageToLoad()
        {
            if (_stageToLoad == Stage.Saved)
                return SaveSystem.Stage.Load();
            else
                return $"Level {(int)_stageToLoad}";
        }

        private void SetLanguage()
        {
            string language = SaveSystem.Settings.LoadLanguage();

#if UNITY_WEBGL && !UNITY_EDITOR
            if (language == null)
            {
                LeanLanguage leanLanguage = null;
                string languageCode = YandexGamesSdk.Environment.i18n.lang;
                leanLanguage = _languages.Find(lang => lang.TranslationCode == languageCode);

                if (leanLanguage != null)
                    language = leanLanguage.name;
            }
#endif

            Config.Language.CurrentLanguage = language == null ? Config.Language.DefaultLanguage : language;
            SaveSystem.Settings.SaveLanguage(Config.Language.CurrentLanguage);
            LeanLocalization.SetCurrentLanguageAll(Config.Language.CurrentLanguage);
        }

        private void RequestData()
        {
            if (YandexGamesSdk.IsInitialized)
            {
                if (PlayerAccount.HasPersonalProfileDataPermission == false)
                    PlayerAccount.RequestPersonalProfileDataPermission();
            }
        }

        private enum Stage
        {
            Saved,
            Level1,
            Level2,
            Level3,
            Level4,
            Level5,
            Level6,
            Level7,
            Level8,
            Level9,
            Level10
        }
    }
}