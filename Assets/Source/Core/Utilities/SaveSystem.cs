using ElasticRush.Core;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ElasticRush.Utilities
{
    public static class SaveSystem
    {
        public const string BestScore = "BestScore";
        public const string CurrentStage = "CurrentStage";

        public static class Player
        {
            public static void Save(Core.Player player)
            {
                if (player == null)
                    throw new ArgumentNullException(nameof(player), "Player can't be null");

                int lastBestScore = Load();

                if (player.Score > lastBestScore)
                    PlayerPrefs.SetFloat(BestScore, player.Score);

                PlayerPrefs.Save();
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
            public static void Save()
            {
                PlayerPrefs.SetString(CurrentStage, SceneManager.GetActiveScene().name);

                PlayerPrefs.Save();
            }

            public static string Load()
            {
                string currentStage = Config.StartLevel;

                if (PlayerPrefs.HasKey(CurrentStage))
                    currentStage = PlayerPrefs.GetString(CurrentStage);

                return currentStage;
            }
        }
    }
}