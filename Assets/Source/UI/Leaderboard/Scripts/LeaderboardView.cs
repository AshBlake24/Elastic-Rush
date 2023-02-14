using UnityEngine;
using Agava.YandexGames;
using ElasticRush.Utilities;

namespace ElasticRush.UI
{
    public class LeaderboardView : MonoBehaviour
    {
        private const int TopPlayersCount = 10;

        [SerializeField] private LeaderboardEntryView _leaderboardEntryViewPrefab;
        [SerializeField] private Transform _container;

        private void OnEnable()
        {
            Leaderboard.GetEntries(Config.LeaderboardName, (result) =>
            {
                foreach (var entry in result.entries)
                {
                    LeaderboardEntryView view = Instantiate(_leaderboardEntryViewPrefab, _container);
                    view.SetData(new LeaderboardEntry(entry));
                }
            }, null, TopPlayersCount);
        }
    }
}
