using ElasticRush.Core;

namespace ElasticRush.UI
{
    public class GameOverScreen : EndScreen
    {
        private void OnEnable()
        {
            if (Player != null)
                Player.Died += OnPlayerDied;
        }

        private void OnDisable()
        {
            if (Player != null)
                Player.Died -= OnPlayerDied;
        }

        public override void Init(Player player)
        {
            Player = player;
            Player.Died += OnPlayerDied;
            Score.Init(player);
        }

        private void OnPlayerDied() => ShowEndScreen();
    }
}