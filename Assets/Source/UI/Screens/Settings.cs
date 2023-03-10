using ElasticRush.Core;
using Lean.Localization;
using System;
using UnityEngine;

namespace ElasticRush.UI
{
    public class Settings : MonoBehaviour
    {
        [SerializeField] private PlayerSensitivitySettings _playerSensitivitySettings;
        [SerializeField] private ChangeLanguageButton _russianButton;
        [SerializeField] private ChangeLanguageButton _englishButton;
        [SerializeField] private ChangeLanguageButton _turkishButton;

        private float _lastTimeScale = 1;

        private void OnEnable()
        {
            _lastTimeScale = Time.timeScale;
            Time.timeScale = 0;
        }

        private void OnDisable()
        {
            Time.timeScale = _lastTimeScale;
        }

        public void Init(PlayerController playerController, LeanLanguage[] languages)
        {
            _playerSensitivitySettings.Init(playerController);
            SetLanguages(languages);
        }

        private void SetLanguages(LeanLanguage[] languages)
        {
            foreach (LeanLanguage language in languages)
            {
                switch (language.name)
                {
                    case "Russian":
                        _russianButton.SetLanguage(language);
                        break;
                    case "English":
                        _englishButton.SetLanguage(language);
                        break;
                    case "Turkish":
                        _turkishButton.SetLanguage(language);
                        break;
                    default:
                        throw new ArgumentNullException($"Button for {language.name} language doesn't exist");
                }
            }
        }
    }
}