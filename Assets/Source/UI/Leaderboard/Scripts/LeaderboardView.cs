using UnityEngine;
using Agava.YandexGames;

namespace ElasticRush.UI
{
    public class LeaderboardView : MonoBehaviour
    {
        private const string LeaderboardName = "Leaderboard";
        private const int TopPlayersCount = 10;

        [SerializeField] private LeaderboardEntryView _leaderboardEntryViewPrefab;
        [SerializeField] private Transform _container;

        private void OnEnable()
        {
            Leaderboard.GetEntries(LeaderboardName, (result) =>
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
