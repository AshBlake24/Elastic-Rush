using System;
using UnityEngine;
using Agava.YandexGames;
using ElasticRush.Core;

namespace ElasticRush.Utilities
{
    public static class SaveSystem
    {
        public static class StageScore
        {
            public static void Save(Player player, string stage)
            {
                if (player == null)
                    throw new ArgumentNullException(nameof(player), "Player can't be null");

                int lastBestScore = Load(stage);

                if (player.Score > lastBestScore)
                {
                    PlayerPrefs.SetFloat(stage, player.Score);
                    PlayerPrefs.Save();
                }
            }

            public static int Load(string stage)
            {
                int bestStageScore = 0;

                if (PlayerPrefs.HasKey(stage))
                    bestStageScore = (int)PlayerPrefs.GetFloat(stage);

                return bestStageScore;
            }
        }

        public static class PlayerScore
        {
            
        }

        public static class Stage
        {
            private const string CurrentStage = nameof(CurrentStage);

            public static void Save(string sceneName)
            {
                PlayerPrefs.SetString(CurrentStage, sceneName);
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
    }
}