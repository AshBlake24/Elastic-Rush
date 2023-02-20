using UnityEngine;
using UnityEngine.UI.Extensions;
using Lean.Localization;

namespace ElasticRush.UI
{
    public class ChangeLanguageButton : Button
    {
        [SerializeField] private LeanLanguage _language;

        protected override void OnButtonClick()
        {
            LeanLocalization.SetCurrentLanguageAll(_language.name);
        }
    }
}
