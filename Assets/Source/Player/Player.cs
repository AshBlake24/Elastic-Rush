namespace ElasticRush.Core
{
    public class Player : ElasticBall
    {
        private int _score;

        public int Score => _score;

        public void AddScore(int score)
        {
            _score += score;
        }

        public void LevelUp(int level = 1)
        {
            Level += level;

            SetLevel(Level);
        }
    }
}