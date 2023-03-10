using ElasticRush.Core;
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

        public Tutorial Tutorial => _tutorial;

        public void Init(Camera camera, Player player, PlayerController playerController)
        {
            _canvas.renderMode = RenderMode.ScreenSpaceCamera;
            _canvas.worldCamera = camera;

            _levelScore.Init(player);
            _settings.Init(playerController);
        }
    }
}