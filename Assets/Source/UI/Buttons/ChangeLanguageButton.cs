using UnityEngine;
using UnityEngine.UI.Extensions;
using Lean.Localization;
using ElasticRush.Utilities;

namespace ElasticRush.UI
{
    public class ChangeLanguageButton : Button
    {
        [SerializeField] private LeanLanguage _language;

        protected override void OnButtonClick()
        {
            Config.Language.CurrentLanguage = _language.name;
            SaveSystem.Settings.SaveLanguage(Config.Language.CurrentLanguage);
            LeanLocalization.SetCurrentLanguageAll(Config.Language.CurrentLanguage);
        }
    }
}