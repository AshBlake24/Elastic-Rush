using UnityEngine;
using UnityEngine.UI.Extensions;
using Lean.Localization;
using ElasticRush.Utilities;
using System;

namespace ElasticRush.UI
{
    public class ChangeLanguageButton : Button
    {
        private LeanLanguage _language;

        public static event Action LanguageChanged;

        public void SetLanguage(LeanLanguage language) => _language = language;

        protected override void OnButtonClick()
        {
            Config.Language.CurrentLanguage = _language.name;
            SaveSystem.Settings.SaveLanguage(Config.Language.CurrentLanguage);
            LeanLocalization.SetCurrentLanguageAll(Config.Language.CurrentLanguage);
            LanguageChanged?.Invoke();
        }
    }
}