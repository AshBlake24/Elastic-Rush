using System;
using ElasticRush.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ElasticRush.Utilities
{
    public static class SaveSystem
    {
        private const string BestScore = "BestScore";
        private const string CurrentStage = "CurrentStage";

        public static class PlayerScore
        {
            public static void Save(Player player)
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
                string currentStage = StageManager.StartLevel;

                if (PlayerPrefs.HasKey(CurrentStage))
                    currentStage = PlayerPrefs.GetString(CurrentStage);

                return currentStage;
            }
        }

        public static void SaveAll(Player player)
        {
            PlayerScore.Save(player);
            Stage.Save();
        }
    }
}