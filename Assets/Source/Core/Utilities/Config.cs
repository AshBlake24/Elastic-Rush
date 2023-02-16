namespace ElasticRush.Utilities
{
    public static class Config
    {
        public static class Leaderboard
        {
            public const string LeaderboardName = "Leaderboard";
            public const int TopPlayersCount = 5;
        }

        public static class Languages
        {
            public const string DefaultLanguage = "English";

            public static string CurrentLanguage = DefaultLanguage;
        }
    }
}
