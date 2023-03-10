using ElasticRush.Core;

namespace ElasticRush.UI
{
    public class LevelCompletedScreen : EndScreen
    {
        private void OnEnable()
        {
            if (Player != null)
                Player.LevelCompleted += OnLevelCompleted;
        }

        private void OnDisable()
        {
            if (Player != null)
                Player.LevelCompleted -= OnLevelCompleted;
        }

        public override void Init(Player player)
        {
            Player = player;
            Player.LevelCompleted += OnLevelCompleted;
            Score.Init(player);
        }

        private void OnLevelCompleted() => ShowEndScreen();
    }
}