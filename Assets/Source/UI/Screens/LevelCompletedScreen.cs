using ElasticRush.Core;

namespace ElasticRush.UI
{
    public class LevelCompletedScreen : EndScreen
    {
        private void OnEnable()
        {
            Player.LevelCompleted += OnLevelCompleted;
        }

        private void OnDisable()
        {
            Player.LevelCompleted -= OnLevelCompleted;
        }

        private void OnLevelCompleted() => ShowEndScreen();
    }
}