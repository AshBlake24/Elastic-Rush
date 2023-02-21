using ElasticRush.Core;

namespace ElasticRush.UI
{
    public class GameOverScreen : EndScreen
    {
        private void OnEnable()
        {
            Player.Died += OnPlayerDied;
        }

        private void OnDisable()
        {
            Player.Died -= OnPlayerDied;
        }

        private void OnPlayerDied() => ShowEndScreen();
    }
}