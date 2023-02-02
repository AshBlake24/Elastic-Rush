namespace ElasticRush.Core
{
    public struct PlayerData
    {
        public int BestScore { get; private set; }

        public PlayerData(int bestScore)
        {
            BestScore = bestScore;
        }
    }
}