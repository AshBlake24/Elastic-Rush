using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using ElasticRush.Utilities;
using Lean.Localization;
using TMPro;

namespace ElasticRush
{
    public class LevelScreen : MonoBehaviour
    {
        private const string LevelLeanPhrase = "Level";

        [SerializeField] private TMP_Text _levelScreen;

        private void OnEnable()
        {
            SceneManager.activeSceneChanged += OnActiveSceneChanged;
        }

        private void OnDisable()
        {
            SceneManager.activeSceneChanged -= OnActiveSceneChanged;
        }

        private void OnActiveSceneChanged(Scene previousScene, Scene currentScene)
        {
            if (currentScene.name == Config.CoreScene)
                return;

            string level = LeanLocalization.GetTranslationText(LevelLeanPhrase);
            string levelNumber = currentScene.name
                .Split(' ')
                .Single(x => x.All(char.IsDigit));

            _levelScreen.text = $"{level} {levelNumber}";
        }
    }
}