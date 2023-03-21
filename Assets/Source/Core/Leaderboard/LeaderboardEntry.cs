using Agava.YandexGames;
using static UnityEngine.EventSystems.EventTrigger;

namespace ElasticRush
{
    public class LeaderboardEntry
    {
        private const string Anonymous = nameof(Anonymous);

        public string PlayerName { get; private set; }
        public string Score { get; private set; }
        public string Rank { get; private set; }

        public LeaderboardEntry(LeaderboardEntryResponse entry)
        {
            if (entry == null)
                return;

            SetName(entry.player.publicName);
            Score = entry.score.ToString();
            Rank = entry.rank.ToString();
        }

        private void SetName(string name)
        {
            PlayerName = name;

            if (string.IsNullOrEmpty(PlayerName))
                PlayerName = Anonymous;
        }
    }
}