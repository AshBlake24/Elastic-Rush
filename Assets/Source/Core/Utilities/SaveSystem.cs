using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Agava.YandexGames;
using ElasticRush.Core;

namespace ElasticRush.Utilities
{
    public static class SaveSystem
    {
        public static class PlayerScore
        {
            private const string BestScore = nameof(BestScore);

            public static void Save(Player player)
            {
                if (player == null)
                    throw new ArgumentNullException(nameof(player), "Player can't be null");

                int lastBestScore = Load();

                if (player.Score > lastBestScore)
                {
#if UNITY_WEBGL || !UNITY_EDITOR
                    Leaderboard.SetScore(Config.Leaderboard.LeaderboardName, player.Score);
#endif
                    PlayerPrefs.SetFloat(BestScore, player.Score);
                    PlayerPrefs.Save();
                }
            }

            public static int Load()
            {
                int bestScore = 0;

                if (PlayerPrefs.HasKey(BestScore))
                    bestScore = (int)PlayerPrefs.GetFloat(BestScore);

                return bestScore;
            }
        }

        public static class Stage
        {
            private const string CurrentStage = nameof(CurrentStage);

            public static void Save()
            {
                PlayerPrefs.SetString(CurrentStage, SceneManager.GetActiveScene().name);

                PlayerPrefs.Save();
            }

            public static string Load()
            {
                string currentStage = StageManager.StartLevel;

                if (PlayerPrefs.HasKey(CurrentStage))
                    currentStage = PlayerPrefs.GetString(CurrentStage);

                return currentStage;
            }
        }

        public static class Settings
        {
            private const string Sensitivity = nameof(Sensitivity);

            public static void SaveSensitivity(float value)
            {
                PlayerPrefs.SetFloat(Sensitivity, value);
                PlayerPrefs.Save();
            }

            public static float LoadSensitivity()
            {
                float sensitivity = Utilities.Sensitivity.DefaultValue;

                if (PlayerPrefs.HasKey(Sensitivity))
                    sensitivity = PlayerPrefs.GetFloat(Sensitivity);

                return sensitivity;
            }
        }

        public static void SaveAll(Player player)
        {
            PlayerScore.Save(player);
            Stage.Save();
        }
    }
}