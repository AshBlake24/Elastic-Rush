using ElasticRush.Core;
using Lean.Localization;
using UnityEngine;

namespace ElasticRush.UI
{
    public class UserInterface : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Tutorial _tutorial;
        [SerializeField] private Settings _settings;
        [SerializeField] private LevelScore _levelScore;
        [SerializeField] private GameOverScreen _gameOverScreen;
        [SerializeField] private LevelCompletedScreen _levelCompletedScreen;
        [SerializeField] private ChangeSceneButton _nextLevelButton;
        [SerializeField] private AdButton _adButton;

        public Tutorial Tutorial => _tutorial;

        public void Init(
            Camera camera, 
            Player player, 
            PlayerController playerController, 
            LeanLanguage[] languages, 
            string nextLevel)
        {
            _canvas.renderMode = RenderMode.ScreenSpaceCamera;
            _canvas.worldCamera = camera;

            _levelScore.Init(player);
            _settings.Init(playerController.Sensitivity, languages);
            _gameOverScreen.Init(player);
            _levelCompletedScreen.Init(player);
            _nextLevelButton.Init(nextLevel);
            _adButton.Init(player);
        }
    }
}