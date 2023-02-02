using ElasticRush.Core;
using System;
using UnityEngine;

namespace ElasticRush.Utilities
{
    public static class SaveSystem
    {
        public static class Player
        {
            public const string BestScore = "BestScore";

            public static void Save(Core.Player player)
            {
                if (player == null)
                    throw new ArgumentNullException(nameof(player), "Player can't be null");

                PlayerData playerData = Load();

                if (player.Score > playerData.BestScore)
                {
                    PlayerPrefs.SetFloat(BestScore, player.Score);
                    PlayerPrefs.Save();
                }
            }

            public static PlayerData Load()
            {
                int bestScore = 0;

                if (PlayerPrefs.HasKey(BestScore))
                    bestScore = (int)PlayerPrefs.GetFloat(BestScore);

                return new PlayerData(bestScore);
            }
        }
    }
}