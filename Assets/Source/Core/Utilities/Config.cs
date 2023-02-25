namespace ElasticRush.Utilities
{
    public static class Config
    {
        public static class Stage
        {
            public static string CoreScene = "Core";
            public static string StartScene = "Level 1";
        }

        public static class Leaderboard
        {
            public const string LeaderboardName = "Leaderboard";
            public const int TopPlayersCount = 5;
        }

        public static class Language
        {
            public const string DefaultLanguage = "English";

            public static string CurrentLanguage;
        }

        public static class Player
        {
            public const float TimeBeforeEndScreen = 1f;
            public const float TimeToStopRolling = 2f;
        }
    }
}