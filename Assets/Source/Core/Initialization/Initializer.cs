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
        [SerializeField] private string _startScene;

        private void Awake()
        {
            YandexGamesSdk.CallbackLogging = true;
        }

        private void Start()
        {
            string scene;

            if (_stageToLoad == Stage.Saved)
                scene = SaveSystem.Stage.Load();
            else
                scene = $"Level {(int)_stageToLoad}";

            SceneLoader.Instance.LoadScene(scene);
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

//            string scene = SaveSystem.Stage.Load();
//            SceneLoader.Instance.LoadScene(scene);
//        }

        private void SetLanguage()
        {
            LeanLanguage leanLanguage = null;
            string languageCode = YandexGamesSdk.Environment.i18n.lang;
            leanLanguage = _languages.Find(lang => lang.TranslationCode == languageCode);
            Config.Language.CurrentLanguage = leanLanguage == null ? Config.Language.DefaultLanguage : leanLanguage.name;

            LeanLocalization.SetCurrentLanguageAll(Config.Language.CurrentLanguage);
        }

        private enum Stage
        {
            Saved,
            Level1,
            Level2,
            Level3,
            Level4
        }
    }
}